       public class MonthTimer : IDisposable
    {
        public event EventHandler<MonthChangedEventArgs> MonthChanged;
        DateTime mLastTimerDate;
        Timer mTimer;
        public MonthTimer(TimeSpan timeOfFirstDay)
            : this(DateTime.Now, timeOfFirstDay)
        {
        }
        public MonthTimer(DateTime currentDate, TimeSpan timeOfFirstDay)
        {
            mLastTimerDate = currentDate.Date;
            var milliSecondsInDay = new TimeSpan(1, 0, 0, 0).TotalMilliseconds;
            Contract.Assert(timeOfFirstDay.TotalMilliseconds <= milliSecondsInDay); // time within 1st day of month            
            DateTime currentDateLastSecond = currentDate.Date.AddDays(1).AddTicks(-1);  // one tick before midnight 
            TimeSpan timeSpanInCurrentDate = currentDateLastSecond.Subtract(currentDate); // remaining time till today ends
            // I want the timer to check every day at specifed time (as in timeOfFirstDay) if the month has changed 
            // therefore at first I would like timer's timeout to be until the same time, following day
            var milliSecondsTillTomorrow = (timeSpanInCurrentDate + timeOfFirstDay).TotalMilliseconds;
            // since out milliseconds will never exceed - . Its okay to convert them to int32
            mTimer = new Timer(TimerTick, null, Convert.ToInt32(milliSecondsTillTomorrow), Convert.ToInt32(milliSecondsInDay));
        }
        private void TimerTick(object state)
        {
            if(DateTime.Now.Month != mLastTimerDate.Month)
            {
                if (MonthChanged != null)
                    MonthChanged(this, new MonthChangedEventArgs(mLastTimerDate, DateTime.Now.Date));
            }
            mLastTimerDate = DateTime.Now.Date;
        }
        public void Dispose()
        {
            mTimer.Dispose();
        }
    }
    public class MonthChangedEventArgs : EventArgs
    {
       public MonthChangedEventArgs(DateTime previousMonth, DateTime currentMonth)
        {
            CurrentMonth = currentMonth;
            PreviousMonth = previousMonth;
        }
       public DateTime CurrentMonth
        {
            get;
            private set;
        }
       public DateTime PreviousMonth
       {
           get;
           private set;
       }
    }
