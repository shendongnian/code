    public static event EventHandler<TickerEventArgs> TickerLoopIterated;
    
    private static void InvokeTickerLoopEvent(string firstTicker, string secondTicker)
    {
        if (null != TickerLoopIterated)
        { 
            var args = new TickerEventArgs() { FirstTicker = firstTicker, SecondTicker = secondTicker };
            TickerLoopIterated(this, args); 
        }
    }
    public class TickerEventArgs : EventArgs
    {
        public string FirstTicker { get; set; }
        public string SecondTicker { get; set; }
    }
