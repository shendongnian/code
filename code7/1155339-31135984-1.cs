    public bool sendMsg(string smsid, string PhoneNo, string Message, string from, string to)
    {
        string recievedData;
        bool isSend = false;
        string text = "Hello " + to + ",\n" + Message + "\n\n" + from;
        if (!port.IsOpen)                
            port = OpenPort();
        recievedData = ExecCommand(port, "AT+CMGF=1", 400, "Failed to set message format.");
            
        try
        {
            //string recievedData; // = ExecCommand(port, "AT", 3000, "No phone connected");
            String command = "AT+CMGS=\"" + PhoneNo + "\"";
            recievedData = ExecCommand(port, command, 1000, "Failed to accept phoneNo");
            command = text + char.ConvertFromUtf32(26) + "\r";
            recievedData = ExecCommand(port, command, 1000, "Failed to send message");
            if (recievedData.Contains("OK"))
            {
                isSend = true;                  
            }
            else if (recievedData.Contains("ERROR"))
            {
                isSend = false;                
            }
        }
        catch (Exception ex)
        {
            MyLog.Write(new LogPacket(ex, DateTime.Now));
        }
        return isSend;
    }
