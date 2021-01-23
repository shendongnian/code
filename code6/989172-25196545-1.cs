    using System;
    using System.Windows.Forms;
    
    namespace TimerTest.Timing.Timers
    {
        /// <summary>
        /// An abstract class for defining the structure of a timer
        /// </summary>
        public abstract class AbstractTimer
        {
            #region Public Events
    
            /// <summary>
            ///   Event Raised when the Timer has elapsed
            /// </summary>
            public abstract event EventHandler<TickEventArgs> Tick;
    
            #endregion
    
            #region Properties
    
            /// <summary>
            ///   Determines whether or not the timer is enabled
            /// </summary>
            public abstract bool Enabled { get; set; }
    
            /// <summary>
            ///   The form which the timer will invoke the Tick event on
            /// </summary>
            public abstract Form Form { get; }
    
            /// <summary>
            ///   The length of the interval in milliseconds
            /// </summary>
            public abstract double IntervalLength { get; set; }
    
            /// <summary>
            ///   The number of intervals that have elapsed
            /// </summary>
            public abstract int IntervalsElapsed { get; }
    
            /// <summary>
            ///   The name of the timer
            /// </summary>
            public abstract string Name { get; }
    
            /// <summary>
            ///   The time at which the timer started
            /// </summary>
            public abstract DateTime StartTime { get; }
    
            #endregion
    
            #region Public Methods
    
            /// <summary>
            ///   Star the timer
            /// </summary>
            public abstract void Start();
    
            /// <summary>
            /// Attempt to stop the timer
            /// </summary>
            /// <returns>True if the timer was successfully stopped, false if not</returns>
            public abstract bool Stop();
    
            #endregion
        }
    }
