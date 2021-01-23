    try
    {
        PingReply reply = pingSender.Send(nameOrAddress);
    	
    	if (reply.Status == IPStatus.Success)
    	{
    		MessageBox.Show("The IP address is: ", "Great sucess!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    	}
    	else
    	{
    	}
    }
    catch (PingException)
    {
        // Discard PingExceptions
    }
