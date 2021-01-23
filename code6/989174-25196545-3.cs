    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace TimerTest.Timing.Timers
    {
        /// <summary>
        ///   A wrapper for a winmm.dll timer
        /// </summary>
        public class MultimediaTimer : AbstractTimer
        {
            #region Public Events
    
            /// <summary>
            ///   Event Raised when the Timer has elapsed
            /// </summary>
            public override event EventHandler<TickEventArgs> Tick;
    
            #endregion
    
            #region Private Fields
    
            private bool _enabled;
            private readonly Form _form;
            private double _intervalLength;
            private int _intervalsElapsed;
            private DateTime _startTime;
    
            private UInt32 _timerId;
    
            #endregion
    
            #region Properties
    
            public override bool Enabled
            {
                get { return _enabled; }
                set
                {
                    if (value)
                    {
                        Start();
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
    
            public override Form Form
            {
                get { return _form; }
            }
    
            public override double IntervalLength
            {
                get { return _intervalLength; }
                set { _intervalLength = value; }
            }
    
            public override int IntervalsElapsed
            {
                get { return _intervalsElapsed; }
            }
    
            public override string Name
            {
                get { return "MultiMedia Timer"; }
            }
    
            public override DateTime StartTime
            {
                get { return _startTime; }
            }
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            ///   Initializes an instance of MultimediaTimer
            /// </summary>
            /// <param name="form"> The form which the timer will invoke the Tick event on </param>
            /// <param name="intervalLength"> The length of the interval in milliseconds </param>
            public MultimediaTimer(Form form, double intervalLength)
            {
                _form = form;
                _intervalLength = intervalLength;
            }
    
            #endregion
    
            #region Public Methods
    
            public override void Start()
            {
                if (Enabled)
                    return;
    
                uint interval = Convert.ToUInt32(Math.Round(_intervalLength, 0));
                _timerId = Winmm.Start(interval, TimerCallback);
                _startTime = DateTime.Now;
    
                _enabled = true;
            }
    
            public override bool Stop()
            {
                if (Enabled)
                {
                    bool stopped = Winmm.Stop(_timerId);
                    _enabled = !stopped;
                    return stopped;
                }
                return false;
            }
    
            #endregion
    
            #region Private Methods
    
            private void TimerCallback(int id, int msg, IntPtr user, int dw1, int dw2)
            {
                _intervalsElapsed++;
                if (Enabled)
                {
                    TriggerTick();
                }
            }
    
            private void TriggerTick()
            {
                DateTime currentTime = DateTime.Now;
    
                _form.BeginInvoke((MethodInvoker) delegate
                                                      {
                                                          TickEventArgs tickEventArgs = new TickEventArgs(StartTime,
                                                                                                          IntervalsElapsed,
                                                                                                          IntervalLength,
                                                                                                          currentTime);
                                                          if (Tick != null)
                                                          {
                                                              Tick(this, tickEventArgs);
                                                          }
                                                      });
            }
    
            #endregion
    
            #region Nested Classes
    
            /// <summary>
            ///   A static wrapper for Winmm.dll
            /// </summary>
            public static class Winmm
            {
                #region Static Private Fields
    
                /// <summary>
                ///   The Event Type
                /// </summary>
                private const int _EVENT_TYPE = _TIME_PERIODIC; // + 0x100;  // TIME_KILL_SYNCHRONOUS causes a hang ?!
    
                private const int _TIME_PERIODIC = 1;
    
                /// <summary>
                ///   The Event Handler for the timer
                /// </summary>
                private static TimerEventHandler _mHandler;
    
                #endregion
    
                #region Static Public Methods
    
                /// <summary>
                ///   Start
                /// </summary>
                /// <param name="interval"> The interval between ticks in ms </param>
                /// <param name="timerCallBack"> The delegate to call on each tick </param>
                /// <returns> The Timer ID </returns>
                public static UInt32 Start(uint interval, TimerEventHandler timerCallBack)
                {
                    timeBeginPeriod(1);
                    _mHandler = timerCallBack;
                    return timeSetEvent(interval, 0, _mHandler, IntPtr.Zero, _EVENT_TYPE);
                }
    
                /// <summary>
                ///   Stop a timer with a given ID
                /// </summary>
                /// <param name="mTimerId"> The Timer ID of the timer to stop </param>
                /// <returns> </returns>
                public static bool Stop(UInt32 mTimerId)
                {
                    UInt32 err = timeKillEvent(mTimerId);
    
                    if (err != (int) Mmresult.Mmsyserr_Noerror)
                        return false;
    
                    timeEndPeriod(1);
                    // Ensure callbacks are drained
                    Thread.Sleep(100);
                    return true;
                }
    
                #endregion
    
                #region Static Private Methods
    
                [DllImport("winmm.dll")]
                private static extern int timeBeginPeriod(int msec);
    
                [DllImport("winmm.dll")]
                private static extern int timeEndPeriod(int msec);
    
                /// <summary>
                ///   The multi media timer stop function
                /// </summary>
                /// <param name="uTimerId"> timer id from timeSetEvent </param>
                /// <remarks>
                ///   This function stops the timer
                /// </remarks>
                [DllImport("winmm.dll", SetLastError = true)]
                private static extern UInt32 timeKillEvent(UInt32 uTimerId);
    
                /// <summary>
                ///   A multi media timer with millisecond precision
                /// </summary>
                /// <param name="msDelay"> One event every msDelay milliseconds </param>
                /// <param name="msResolution"> Timer precision indication (lower value is more precise but resource unfriendly) </param>
                /// <param name="handler"> delegate to start </param>
                /// <param name="userCtx"> callBack data </param>
                /// <param name="eventType"> one event or multiple events </param>
                /// <remarks>
                ///   Dont forget to call timeKillEvent!
                /// </remarks>
                /// <returns> 0 on failure or any other value as a timer id to use for timeKillEvent </returns>
                [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeSetEvent")]
                private static extern UInt32 timeSetEvent(UInt32 msDelay, UInt32 msResolution, TimerEventHandler handler,
                                                          IntPtr userCtx, UInt32 eventType);
    
                #endregion
    
                #region Public Delegates
    
                /// <summary>
                ///   The Timer's Event Handler
                /// </summary>
                /// <param name="id"> </param>
                /// <param name="msg"> </param>
                /// <param name="user"> </param>
                /// <param name="dw1"> </param>
                /// <param name="dw2"> </param>
                public delegate void TimerEventHandler(int id, int msg, IntPtr user, int dw1, int dw2);
    
                #endregion
    
                #region Public Enumerators
    
                /// <summary>
                ///   Possible Return Values
                /// </summary>
                public enum Mmresult : uint
                {
                    /// <summary>
                    ///   No Error
                    /// </summary>
                    Mmsyserr_Noerror = 0,
    
                    /// <summary>
                    ///   Error
                    /// </summary>
                    Mmsyserr_Error = 1,
    
                    /// <summary>
                    ///   Bad Device ID
                    /// </summary>
                    Mmsyserr_Baddeviceid = 2,
    
                    /// <summary>
                    ///   Not Enabled
                    /// </summary>
                    Mmsyserr_Notenabled = 3,
    
                    /// <summary>
                    ///   Allocated
                    /// </summary>
                    Mmsyserr_Allocated = 4,
    
                    /// <summary>
                    ///   Invalid Handle
                    /// </summary>
                    Mmsyserr_Invalhandle = 5,
    
                    /// <summary>
                    ///   No Driver
                    /// </summary>
                    Mmsyserr_Nodriver = 6,
    
                    /// <summary>
                    ///   No Mem
                    /// </summary>
                    Mmsyserr_Nomem = 7,
    
                    /// <summary>
                    ///   Not Supported
                    /// </summary>
                    Mmsyserr_Notsupported = 8,
    
                    /// <summary>
                    ///   Bad Error Number
                    /// </summary>
                    Mmsyserr_Baderrnum = 9,
    
                    /// <summary>
                    ///   Invalid Falg
                    /// </summary>
                    Mmsyserr_Invalflag = 10,
    
                    /// <summary>
                    ///   Invalid Parameter
                    /// </summary>
                    Mmsyserr_Invalparam = 11,
    
                    /// <summary>
                    ///   Handle Busy
                    /// </summary>
                    Mmsyserr_Handlebusy = 12,
    
                    /// <summary>
                    ///   Invalid Alias
                    /// </summary>
                    Mmsyserr_Invalidalias = 13,
    
                    /// <summary>
                    ///   Baddb
                    /// </summary>
                    Mmsyserr_Baddb = 14,
    
                    /// <summary>
                    ///   Key Not Found
                    /// </summary>
                    Mmsyserr_Keynotfound = 15,
    
                    /// <summary>
                    ///   Read Error
                    /// </summary>
                    Mmsyserr_Readerror = 16,
    
                    /// <summary>
                    ///   Write Error
                    /// </summary>
                    Mmsyserr_Writeerror = 17,
    
                    /// <summary>
                    ///   Delete Error
                    /// </summary>
                    Mmsyserr_Deleteerror = 18,
    
                    /// <summary>
                    ///   Value Not Found
                    /// </summary>
                    Mmsyserr_Valnotfound = 19,
    
                    /// <summary>
                    ///   No Driver CB
                    /// </summary>
                    Mmsyserr_Nodrivercb = 20,
    
                    /// <summary>
                    ///   Bad Format
                    /// </summary>
                    Waverr_Badformat = 32,
    
                    /// <summary>
                    ///   Still Playing
                    /// </summary>
                    Waverr_Stillplaying = 33,
    
                    /// <summary>
                    ///   Unprepared
                    /// </summary>
                    Waverr_Unprepared = 34
                }
    
                #endregion
            }
    
            #endregion
        }
    }
