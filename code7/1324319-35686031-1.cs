    namespace MyGreatNewTimer
    {
        class BtElapsedEventArgs
        {
            public DateTime SignalTime { get; set; }
            //Some other properties
        }
        class BetterTimer : Timer
        {
            new public event EventHandler<BtElapsedEventArgs> Elapsed;
            public BetterTimer()
            {
                base.Elapsed += BetterTimer_Elapsed;
            }
            void BetterTimer_Elapsed(object sender, ElapsedEventArgs e)
            {
                var handler = this.Elapsed;
                if(handler!=null)
                {
                    var bte = new BtElapsedEventArgs() { SignalTime = e.SignalTime};
                    //Set other properties, then fire the event
                    handler(sender, bte);
                }
            }
        }
    }
