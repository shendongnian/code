    private string incompleteRecord = "";
    public void ReadSocket()
    {
        if (_networkStream.DataAvailable)
        {
            var buffer = new byte[8192];
            var receivedString = new StringBuilder();
            do
            {
                int numberOfBytesRead = _networkStream.Read(buffer, 0, buffer.Length);
                receivedString.AppendFormat("{0}", Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead));
            } while (_networkStream.DataAvailable);
            var bulkMsg = receivedString.ToString();
            // When you receive data from the socket, you can receive any number of messages at a time
            // with no guarantee that the last message you receive will be complete.
            // You can receive only part of a complete message, with next part coming
            // with the next call. So, we need to save any partial messages and add
            // them to the beginning of the data next time.
            bulkMsg = incompleteRecord + bulkMsg;
            // clear incomplete record so it doesn't get processed next time too.
            incompleteRecord = "";
            // loop though the data breaking it apart into lines by delimiter ("\n")
            while (bulkMsg.Length > 0)
            {
                var newLinePos = bulkMsg.IndexOf("\n");
                if (newLinePos > 0)
                {
                    var line = bulkMsg.Substring(0, newLinePos);
                    // Do whatever you want with your line here ...
                    // ProcessYourLine(line)
                    // Move to the next message.
                    bulkMsg = bulkMsg.Substring(line.Length + 1);
                }
                else
                {
                    // there are no more newline delimiters
                    // so we save the rest of the message (if any) for processing with the next batch of received data.
                    incompleteRecord = bulkMsg;
                    bulkMsg = "";
                }
            }
        }
    }
