    public static class NotifierService
    {
        public delegate void NotifierServiceEventHandler(object sender, NotifierServiceEventArgs e);
        public static event NotifierServiceEventHandler OnOk = delegate { };
        public static void NotifyOk(string fullMessage = "Ok.", string shortMessage = null)
        {
            OnOk(typeof(NotifierService), 
                 new NotifierServiceEventArgs(StatusType.Ok, fullMessage, shortMessage ?? fullMessage));
        }
    }
