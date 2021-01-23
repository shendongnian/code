    public static class NotifierService
    {
    	public static void NotifyOk(string fullMessage = "Ok.", string shortMessage = null)
    	{
    		var target = Form.ActiveForm as NotifiedForm;
    		if (target != null)
    			target.OnNotifyOK(typeof(NotifierService), new NotifierServiceEventArgs(StatusType.Ok, fullMessage, shortMessage ?? fullMessage));
    	}
    	// similar for other notifications
    }
