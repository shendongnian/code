    try
            {
                
                string recievedData = ExecCommand(port,"AT", 300, "No phone connected");
                recievedData = ExecCommand(port, "AT+CSCS=\"GSM\"", 300, "Set Charset to GSM");
                recievedData = ExecCommand(port,"AT+CMGF=1", 300, "Failed to set message format.");
                String command = "AT+CMGS=\"" + PhoneNo + "\"";
                recievedData = ExecCommand(port,command, 300, "Failed to accept phoneNo");         
                command = Message + char.ConvertFromUtf32(26) + "\r";
                recievedData = ExecCommand(port,command, 3000, "Failed to send message"); //3 seconds
                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isSend = true;
                }
                else if (recievedData.Contains("ERROR"))
                {
                    isSend = false;
                }
                return isSend;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
