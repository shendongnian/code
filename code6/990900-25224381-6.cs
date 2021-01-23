    public static class StateManager
    {
        public static void IsBusyProcess(Action action)
        {
            IsBusyProcess(action, "Processing...");
        }
        public static void IsBusyProcess(Action action, String isBusyMessage)
        {
            BusyActionEventArgs args = new BusyActionEventArgs()
            {
                IsBusyAction = action,
                BusyMessage = isBusyMessage
            };
            IsBusyChange(null, args);
        }
        public delegate void IsBusyHandler(object sender, BusyActionEventArgs e);
        public static event IsBusyHandler IsBusyChange;
    }
