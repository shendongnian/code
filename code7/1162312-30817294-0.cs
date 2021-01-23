    public bool SendMessage(SerialPort port, string phoneNo, string message)
        {
            bool isSend = false;
            try
            {                
                string recievedData = SendATCommand(port,"AT", 300, "No phone connected");
                string command = "AT+CMGF=1" + char.ConvertFromUtf32(13);
                recievedData = SendATCommand(port,command, 300, "Failed to set message format.");
                // AT Command Syntax - http://www.smssolutions.net/tutorials/gsm/sendsmsat/
                command = "AT+CMGS=\"" + phoneNo + "\"" + char.ConvertFromUtf32(13);
                recievedData = SendATCommand(port, command, 300,
                    "Failed to accept phoneNo");
                command = message + char.ConvertFromUtf32(26);
                recievedData = SendATCommand(port, command, 3000,
                    "Failed to send message"); //3 seconds
                if (recievedData.EndsWith("\r\nOK\r\n"))
                    isSend = true;
                else if (recievedData.Contains("ERROR"))
                    isSend = false;
        
                return isSend;
            }
            catch (Exception ex)
            {
                throw ex; 
            }          
        }
