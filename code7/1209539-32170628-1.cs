        private async Task ListenForMessagesAsync(StreamSocket localsocket)
        {
            while (socket != null)
            {
                try
                {
                    string message = String.Empty;
                    DataReader dataReader = new DataReader(localsocket.InputStream);
                    dataReader.InputStreamOptions = InputStreamOptions.Partial;
                    // Read the message and process it.
                    lock (this.interlock)
                    {
                        if (!message.Contains("\r\n"))
                            readBuffer = readBuffer + message;
                        else
                        {
                            var data = message.Split('\r');
                            readBuffer = readBuffer + data[0];
                        }
                        if (readBuffer.Length == 15)
                        {
                            readBuffer = readBuffer.Replace("\r\n", "");
                            OnMessageReceivedEvent(this, readBuffer);
                            readBuffer = String.Empty;
                        }
                        if (readBuffer.Length > 15 || (readBuffer.Length < 15 && readBuffer.Contains("\r\n")))
                            readBuffer = String.Empty;
                    }
                    
                }
                catch (Exception ex)
                {
                    if (socket != null)
                        OnExceptionOccuredEvent(this, ex);
                }
            }
        }
