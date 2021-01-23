    private string sendCommand(string cmd)
    	{
    		string command = cmd + "\r";
    		string response = "";
    		try
    		{
    			sp.Write(cmd);     //There's my problem!
    			response = sp.ReadTo("\r");
    		}
    		catch (Exception e)
    		{	
    			Debug.WriteLine("Send Command: " + cmd + " : " + e.Message);
    		}
            return response;
   		}
