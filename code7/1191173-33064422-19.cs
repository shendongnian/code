    public static class NotifierService
    {
    	public static void NotifyOk(string fullMessage = "Ok.", string shortMessage = null)
    	{
    		// Could also be a forward for, forach etc.
    		for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
    		{
    			var target = Application.OpenForms[i] as NotifiedForm;
    			if (target != null /* && someOtherCritaria(target) */)
    			{
    				target.OnNotifyOK(typeof(NotifierService), new NotifierServiceEventArgs(StatusType.Ok, fullMessage, shortMessage ?? fullMessage));
    				// Could also continue
    				break;
    			}
    		}
    	}
    	// similar for other notifications
    }
