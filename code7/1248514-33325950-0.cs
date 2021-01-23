    //Write message in RichTextBox
            string msg = encoder.GetString(message, 0, bytesRead);
            WriteMessage(msg);
        }
        tcpClient.Close();
    }
    private void WriteMessage(string msg)
    {
        if (this.rtbServer.InvokeRequired)
        {
            WriteMessageDelegate d = new WriteMessageDelegate(WriteMessage);
            this.rtbServer.Invoke(d, new object[] { msg });
        }
        else
        {
            this.rtbServer.AppendText(msg + Environment.NewLine);
    // SEND KEYSTROKES TO ACTIVE WINDOW
    if (msg.Equals("CTRL-T"))
            {
                SendKeys.Send("^T");
            }
            else if (msg.Equals("CTRL-H"))
            {
                SendKeys.Send("^H");
            }
            else
            {
                SendKeys.Send(msg);
            }
