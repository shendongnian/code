    public class TypeAssistant
    {
            public event EventHandler Idled = delegate { };
            public int WaitingMilliSeconds { get; set; }
            System.Threading.Timer waitingTimer;
    
            public TypeAssistant(waitingMilliSeconds = 600)
            {
                WaitingMilliSeconds = waitingMilliSeconds;
                CurrentStatus = Status.Idle;
                waitingTimer = new Timer(p =>
                {
                    Idled(this, EventArgs.Empty);
                });
            }
            public void TextChanged()
            {
                waitingTimer.Change(WaitingMilliSeconds, System.Threading.Timeout.Infinite);
            }
    }
    
