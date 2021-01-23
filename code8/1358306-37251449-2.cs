    // Write to Chat
        private void writeMessageToChat(object sender, IncomingMessageEventArgs e)
        {
            try
            {
                if (!Dispatcher.CheckAccess())
                { 
                    Dispatcher.Invoke(new writeMessageToChatEventHandler(writeMessageToChat), new object[] { sender, e } );
                    return;
                }
                textBox_Chat.AppendText(e.Message.getFormatedMessageText() + "\n");
            }
            catch (Exception ex)
            {
                writeLogToChat(this, new IncomingLogEventArgs("ERROR: " + ex.Message));
            }
        }
