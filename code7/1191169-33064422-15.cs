    public static class NotifierService
    {
    	public delegate void NotifierServiceEventHandler(object sender, NotifierServiceEventArgs e);
    	public static event NotifierServiceEventHandler OnOk;
    	public static void NotifyOk(string fullMessage = "Ok.", string shortMessage = null)
    	{
    		var handler = OnOk;
    		if (handler != null)
    			handler(typeof(NotifierService), new NotifierServiceEventArgs(StatusType.Ok, fullMessage, shortMessage ?? fullMessage));
    	}
    }
