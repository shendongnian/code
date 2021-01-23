    using System;
    using System.Net.Sockets;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    
    namespace TCPServerTest
    {
        class TestEnvironment : IDisposable
        {
            TcpListener TcpServer;
    
            readonly public int TcpServerAddress;
    
            public TestEnvironment(int TcpServerAddress = 5678)
            {
                this.TcpServerAddress = TcpServerAddress;
    
                TcpServer = new TcpListener(IPAddress.Loopback, TcpServerAddress);
    
                TcpServer.Start();
            }
    
            public void Dispose()
            {
                TcpServer.Stop();
            }
        }
    
        [TestClass]
        public class TestContainer
        {
            [TestMethod]
            public void TestUsingTcpServer()
            {
                using (var TestEnvironment = new TestEnvironment())
                {
                    var TcpClient = new TcpClient();
    
                    TcpClient.Connect(IPAddress.Loopback, TestEnvironment.TcpServerAddress);
    
                    Assert.IsTrue(TcpClient.Connected, "TcpClient.Connected");
                }
            }
        }
    }
