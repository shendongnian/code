    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Diagnostics;
    using System.IO;
    namespace ClientSocket_System
      {
       class tcpClientSocket
       {
        #region Global Variables
        TcpClient tcpService;
        IPEndPoint serverEndPoint;
        NetworkStream netStream;
        #endregion
        public void commToServer()
        {
            tcpService = new TcpClient();
            serverEndPoint = new IPEndPoint(IPAddress.Parse("xxx.xxx.xxx.xx"), xxxx); //Enter IP address of computer here along with a port number if needed
            try
            {
                tcpService.Connect(serverEndPoint);
                netStream = tcpService.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes("SwitchComputers");
                netStream.Write(buffer, 0, buffer.Length);
                netStream.Flush();
                tcpService.Close();
            }
            catch(Exception ex)
            {
            }
        }
       }
    }
