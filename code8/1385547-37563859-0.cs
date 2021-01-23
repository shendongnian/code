            private void Connection_StateChanged(StateChange obj)
            {
                //when the connection is Disconnected
                if (obj.NewState == ConnectionState.Disconnected)
                {
                    var current = DateTime.Now.TimeOfDay;
                    // start a timer after 30 secs and retry every 15secs
                    SetTimer(current.Add(TimeSpan.FromSeconds(30)), TimeSpan.FromSeconds(15), StartCon);
                } else {
                    if(_timer!=null)
                       _timer.Dispose();
                }
            }
    
            private async Task StartCon()
            {
                await Connection.Start();
            }
    
            private Timer _timer ;
            private void SetTimer(TimeSpan starTime, TimeSpan every, Func<Task> action)
            {
                var current = DateTime.Now;
                var timeToGo = starTime - current.TimeOfDay;
                if (timeToGo < TimeSpan.Zero)
                {
                    return;
                }
                _timer = new Timer(x =>
                {
                    action.Invoke();
                }, null, timeToGo, every);
            }
