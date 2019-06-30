using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    class TcpNetServer
    {
        private List<Socket> _clientSockets;
        private Socket _coreSocket;
        
        public Socket CoreSocket
        {
            get { return _coreSocket; }
        }
        public List<Socket> ClientSockets
        {
            get { return _clientSockets; }
        }
        public int MaxListenSocket
        {
            set { _maxListenSocket = value; }
            get { return _maxListenSocket; }
        }
        private int socketBufferSize = 1024;
        private int _maxListenSocket;

        public void ServerStart(int port)
        {

            _coreSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _coreSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            _coreSocket.Listen(_maxListenSocket);
            _coreSocket.BeginAccept(new AsyncCallback(AsyncAcceptCallback), _coreSocket);

        }

        private void AsyncAcceptCallback(IAsyncResult ar)
        {
            if(ar.AsyncState is Socket serveSocket)
            {
                Socket clientSocket = null;
                try
                {
                    clientSocket=serveSocket.EndAccept(ar);

                }
                catch
                {

                }
                
            }
        }
    }
}
