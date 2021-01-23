    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace EventsTry
    {
        public delegate void countDownFinishEventHandler(Object sender, EventArgs e);
        public delegate void TimeLeftChangedEventHandler(Object sender, TimeLeftDateEventArgs e);
        class CountDown
        {
            private DateTime _target;
            private System.Windows.Forms.Timer _timer;
            System.TimeSpan _timeMissing;
    
            public event countDownFinishEventHandler CountDownFinish;
            public event TimeLeftChangedEventHandler TimeLeftChanged;
    
            public CountDown(DateTime targetTime)
            {
                this._target = targetTime;
                this._timer = new System.Windows.Forms.Timer();
                this._timeMissing = new TimeSpan();
            }
    
            public DateTime TargetTime
            {
                get { return this._target; }
            }
    
            public TimeSpan timeMissing
            {
                get { return this._timeMissing; }
            }
    
            public void CountDownStart()
            {
                _timer.Interval = 1000;
                _timer.Tick += new EventHandler(timer_tick);
                _timer.Start();
            }
    
            protected virtual void timer_tick(Object sender, EventArgs e)
            {
                System.DateTime now = System.DateTime.Now;
                _timeMissing = _target.Subtract(now);
    
    
                if (!(timeMissing.TotalSeconds > 0))
                {
                    _timer.Stop();
    
    
                    if (CountDownFinish != null)
                    {
                        CountDownFinish(this, EventArgs.Empty);
                    }
                }
                else
                {
                    if (TimeLeftChanged != null)
                    {
                        TimeLeftChanged(this, new TimeLeftDateEventArgs(timeMissing));
                    }
                }
            }
    
        }
    
        public class TimeLeftDateEventArgs : EventArgs
        {
            private int _hours;
            private int _minutes;
            private int _seconds;
    
            public TimeLeftDateEventArgs(TimeSpan timespan)
            {
                _hours = timespan.Hours;
                _minutes = timespan.Minutes;
                _seconds = timespan.Seconds;
    
            }
    
            public int Hours
            { get { return this._hours; } }
    
            public int Minutes
            { get { return this._minutes; } }
    
            public int Seconds
            { get { return this._seconds; } }
    
        }
    
    
    }
