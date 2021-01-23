      public class Server : XSocketController
        {
            public Server()
            { 
                this.OnOpen += onOpen; 
            }
    
            void onOpen(object sender, XSockets.Core.Common.Socket.Event.Arguments.OnClientConnectArgs e)
            {
                this.send("connected");
            }
            public void send(String msg)
            {
                this.send(msg);
            }
    
        }
