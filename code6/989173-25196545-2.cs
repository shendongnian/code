    using System;
    
    namespace TimerTest.Timing.Timers
    {
        /// <summary>
        /// Event Arguments for Tick Events
        /// </summary>
        public class TickEventArgs : EventArgs
        {
            #region Private Fields
    
            private readonly DateTime _currentTime;
            private readonly DateTime _startTime;
            private readonly double _timerIntervalLength;
            private readonly int _timerIntervalsElapsed;
    
            #endregion
    
            #region Properties
    
            /// <summary>
            ///   The current time when the TickEventArgs were created
            /// </summary>
            public DateTime CurrentTime
            {
                get { return _currentTime; }
            }
    
            /// <summary>
            ///   The average number of milliseconds that the the timer has drifted away from the actual time each hour. 
            ///   A negative value indicates that the timer is running slower than the set interval, 
            ///   and a positive value indicates that the timer is running faster than the set interval
            /// </summary>
            public double DriftMsPerHour
            {
                get { return (DriftSecondsTotal*1000*60*60)/ElapsedTime.TotalSeconds; }
            }
    
            /// <summary>
            ///   The average number of milliseconds that the the timer has drifted away from the actual time on each interval. 
            ///   A negative value indicates that the timer is running slower than the set interval, 
            ///   and a positive value indicates that the timer is running faster than the set interval
            /// </summary>
            public double DriftMsPerInterval
            {
                get { return (DriftSecondsTotal*1000)/(ElapsedTime.TotalSeconds*(1000/TimerIntervalLength)); }
            }
    
            /// <summary>
            ///   The average number of milliseconds that the the timer has drifted away from the actual time each minute. 
            ///   A negative value indicates that the timer is running slower than the set interval, 
            ///   and a positive value indicates that the timer is running faster than the set interval
            /// </summary>
            public double DriftMsPerMinute
            {
                get { return (DriftSecondsTotal*1000*60)/(ElapsedTime.TotalSeconds); }
            }
    
            /// <summary>
            ///   The average number of milliseconds that the the timer has drifted away from the actual time each second. 
            ///   A negative value indicates that the timer is running slower than the set interval, 
            ///   and a positive value indicates that the timer is running faster than the set interval
            /// </summary>
            public double DriftMsPerSecond
            {
                get { return (DriftSecondsTotal*1000)/ElapsedTime.TotalSeconds; }
            }
    
            /// <summary>
            ///   The total number of seconds that the timer has drifted away from the actual time. 
            ///   A negative value indicates that the timer is running slower than the set interval, 
            ///   and a positive value indicates that the timer is running faster than the set interval
            /// </summary>
            public double DriftSecondsTotal
            {
                get { return TimerElapsedSeconds - ElapsedTime.TotalSeconds; }
            }
    
            /// <summary>
            ///   The actual number of seconds elapsed
            /// </summary>
            public TimeSpan ElapsedTime
            {
                get { return CurrentTime - StartTime; }
            }
    
            /// <summary>
            ///   The time that the timer started
            /// </summary>
            public DateTime StartTime
            {
                get { return _startTime; }
            }
    
            /// <summary>
            ///   The number of seconds elapsed by the timer
            /// </summary>
            public double TimerElapsedSeconds
            {
                get { return TimerIntervalsElapsed*TimerIntervalLength/1000; }
            }
    
            /// <summary>
            ///   The interval length of the timer
            /// </summary>
            public double TimerIntervalLength
            {
                get { return _timerIntervalLength; }
            }
    
            /// <summary>
            ///   The number of intervals elapsed by the timer
            /// </summary>
            public int TimerIntervalsElapsed
            {
                get { return _timerIntervalsElapsed; }
            }
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            ///   Initializes an instance of TickEventArgs
            /// </summary>
            /// <param name="startTime"> The time that the timer started </param>
            /// <param name="timerIntervalsElapsed"> The number of intervals elapsed by the timer </param>
            /// <param name="timerIntervalLength"> The interval length of the timer </param>
            /// <param name="currentTime"> The current time when the TickEventArgs were created </param>
            public TickEventArgs(DateTime startTime, int timerIntervalsElapsed,
                                 double timerIntervalLength, DateTime currentTime)
            {
                _startTime = startTime;
                _timerIntervalsElapsed = timerIntervalsElapsed;
                _timerIntervalLength = timerIntervalLength;
                _currentTime = currentTime;
            }
    
            #endregion
        }
    }
