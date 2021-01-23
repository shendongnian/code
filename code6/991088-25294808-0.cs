    class WebsocketServer
    {
		private Thread listenThread;
        private WebSocketServer appServer = new WebSocketServer();
		
		public void startServer()
        {
            try
            {
                //konfigure server
                this.appServer.Setup(2014);
                this.appServer.NewMessageReceived += new SessionHandler<WebSocketSession, string>(appServer_NewMessageReceived);
                this.appServer.NewSessionConnected += new SessionHandler<WebSocketSession>(appServer_NewSessionConnected);
                this.appServer.SessionClosed += new SessionHandler<WebSocketSession, CloseReason>(appServer_SessionClosed);
                //Thread starten
                this.listenThread = new Thread(new ThreadStart(startListening));
                this.listenThread.Start();
            }
            catch (Exception e)
            {
                System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
                appLog.Source = "myService";
                appLog.WriteEntry("Couldn´t start Service: " + e.Message);
            }
        }
		
        public void stopServer()
        {
            this.appServer.Stop();
            this.listenThread.Abort();
        }
        private void startListening()
        {
            try
            {
                this.appServer.Start();
            }
            catch (Exception e)
            {
                System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
                appLog.Source = "myService";
                appLog.WriteEntry("Couldn´t start listening: " + e.Message);
            }
        }
        private static void appServer_NewMessageReceived(WebSocketSession session, string message)
        {
            System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
            try
            {
                //Send the received message back
                session.Send("Server: " + message);
            }
            catch (Exception e)
            {
               // System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
                appLog.Source = "myService";
                appLog.WriteEntry("Couldn´t sent message to client: " + e.Message);
            }
            appLog.Source = "myService";
            appLog.WriteEntry("incoming message: " + message);
        }
        private static void appServer_SessionClosed(WebSocketSession session, CloseReason reason)
        {
            System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
            appLog.Source = "myService";
            appLog.WriteEntry("session closed. reason:: " + reason);
        }
        private static void appServer_NewSessionConnected(WebSocketSession session)
        {
            session.Send("Welcome to SuperSocket Server");
        }
	}
