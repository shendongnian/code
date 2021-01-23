    public PositionChangedEventArgs : EventArgs
    {
        public PositionChangedEventArgs(int seconds)
        {
            Seconds = seconds;
        }
        
        public int Seconds { get; set; }
    }
    public interface IAudio
    {
        ...
        event EventHandler<PositionChangedEventArgs> PositionChanged;
    }
