    public enum MailStatus 
    {
        Ok  = 1,
       Bad = 2
    }
    
    public enum DbStatus 
    {
        Ok  = 4,
        Bad = 8
    }
    
    public static void Main()
    {
    	var mailStatus = MailStatus.Ok;
    	var dbStatus = DbStatus.Ok;
    	var status = (int)mailStatus | (int)dbStatus;
        // Example: we test if status matches with EmailStatus.Ok
    	if ((status & (int)MailStatus.Ok) != 0)
        {
    		Console.WriteLine("Ok");
        }
    }
