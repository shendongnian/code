    public static int SshCommand(string command, out string dataOut, out string error)
        {
            dataOut = "";
            error = "";
            
            try
            {
                
                using (var client = new SshClient("127.0.0.1", USER_NAME, PASSWORD))
                {
                    client.Connect();
                    //command = "powershell -Command " + "\u0022" + "set-date -date '8/10/2017 8:30:00 AM'" + "\u0022";
                    //command = "netsh interface ip show config";
                    var cmd = client.RunCommand(command);
                    var output = cmd.Result;
                    client.Disconnect();
                }
                
                return 1;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return 0;
            }
        }
    public static int SSHSetDateTime(DateTime dateTime)
        {
            // Variables
            int returnValue = 0;
            string command;
            string error;
            string dataOut;
            // Build date
            command = String.Format("powershell -Command \u0022set-date -date '{0:M/d/yyyy H:mm:ss tt}'\u0022", dateTime);
            
            //Build date
            if (SystemEx.SshCommand(command, out dataOut, out error) == 1)
            {
                // Ok
                returnValue = 1;
            }
            
            // Return
            return returnValue;
            
        }
