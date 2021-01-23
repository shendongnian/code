    public class BusyActionEventArgs : EventArgs
    {
        public Action IsBusyAction { get; set; }
        public string BusyMessage { get; set; }
    }
