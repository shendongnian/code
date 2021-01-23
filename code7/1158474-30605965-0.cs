           tcHubProxy(HubConnection hubConnection, StreamWriter writer)
        {
            mhubConn = hubConnection;
            mIHubProxy = hubConnection.CreateHubProxy("CentralHub");
            mWriter = writer;
            mWriter.AutoFlush = true;
            try
            {
                mhubConn.TraceLevel = TraceLevels.All;
                mhubConn.TraceWriter = mWriter;
                mhubConn.Closed += MhubConnOnClosed;
                mhubConn.Start().Wait();
                LogEvent(DateTime.Now, "Info", "Client Connected");
                mIHubProxy.On<List<User>>("updateFmds", GetUserFmds);
                connected = true;
            }
            catch (Exception e)
            {
                if (showMessage)
                {
                    MessageBox.Show(
                        "There is currently no connection to the server, this application will close, if this issue persists check your network connection or contact support.",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    showMessage = false;
                } 
                connected = false;
                showMessage = false;
            }
        }
     public void MhubConnOnClosed()
        {
            LogEvent(DateTime.Now, "Info", "Client connection to communication hub, attempting to redirect.");
            try
            {
                mhubConn = new HubConnection(ConnectionString);
                mhubConn.TraceLevel = TraceLevels.All;
                mhubConn.TraceWriter = mWriter;
                mIHubProxy = mhubConn.CreateHubProxy("CentralHub");
                mhubConn.Start().Wait();
                LogEvent(DateTime.Now, "Info", "Reconnection successful.");
                mIHubProxy.On<List<User>>("updateFmds", GetUserFmds);
            }
            catch (Exception e)
            {
                LogEvent(DateTime.Now, "Error", "Reconnection attempt failed.", e.StackTrace, e.Message);
                if (showMessage)
                {
                    MessageBox.Show(
                        "There is currently no connection to the server, this application will close, if this issue persists check your network connection or contact support.",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    showMessage = false;
                }
                connected = false;
            }
        }
