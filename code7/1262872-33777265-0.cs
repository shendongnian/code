    public class TypeAssistant
    {
            public event EventHandler Idled = delegate { };
            public int WaitingMilliSeconds { get; set; }
            Timer waitingTimer = new Timer(p => { });
    
            public TypeAssistant()
            {
                WaitingMilliSeconds = 600;
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
    
