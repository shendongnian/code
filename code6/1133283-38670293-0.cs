        #region OnStart
        protected override void OnStart(string[] args)
        {
            
            System.Data.SqlClient.SqlDependency.Stop(connectionString);
            System.Data.SqlClient.SqlDependency.Start(connectionString);
            BBALogger.Write("PartIndexer Service OnStart called start", BBALogger.MsgType.Info);
            RegisterNotification();
            MailSend(); // notification mail send
            BBALogger.Write("PartIndexer Service OnStart called end, logged in user " + GetLoggedInUser(), BBALogger.MsgType.Info);
        }
        #endregion
