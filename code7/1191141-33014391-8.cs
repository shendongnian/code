    public static class NotifierService
    {
        public static event EventHandler<NotifierServiceEventArgs> OnOk = delegate { };
        public static void NotifyOk(string fullMessage = "Ok.", string shortMessage = null)
        {
            OnOk(typeof(NotifierService), 
                 new NotifierServiceEventArgs(StatusType.Ok, fullMessage, shortMessage ?? fullMessage));
        }
    }
