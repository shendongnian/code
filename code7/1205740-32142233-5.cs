    /// <summary> Wrap System.Timers.Timer class to provide safer exclusive access to serial port </summary>
    class SerialOperationTimer
    {
        private static SerialOperationTimer runningTimer = null; // there should only be one!
        private string name;  // for diagnostics
        // Delegate TYPE for user's callback function (user callback function to make async measurements)
        public delegate void SerialOperationTimerWorkerFunc_T(object source, System.Timers.ElapsedEventArgs e);
        private SerialOperationTimerWorkerFunc_T workerFunc; // application function to call for this timer
        private System.Timers.Timer timer;
        private object workerEnteredLock = new object();
        private bool workerAlreadyEntered = false;
        public SerialOperationTimer(string _name, int msecDelay, SerialOperationTimerWorkerFunc_T func)
        {
            name = _name;
            workerFunc = func;
            timer = new System.Timers.Timer(msecDelay);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(SerialOperationTimer_Tick);
        }
        private void SerialOperationTimer_Tick(object source, System.Timers.ElapsedEventArgs eventArgs)
        {
            lock (workerEnteredLock)
            {
                if (workerAlreadyEntered) return; // don't launch multiple copies of worker if timer set too fast; just ignore this tick
                workerAlreadyEntered = true;
            }
            bool lockTaken = false;
            try
            {
                // Acquire the serial lock prior calling the worker
                Monitor.TryEnter(XXX_Conn.SerialPortLockObject, ref lockTaken);
                // Debug.WriteLine("SerialOperationTimer " + name + ": Got serial lock");
                workerFunc(source, eventArgs);
            }
            finally
            {
                // release serial lock
                if (lockTaken)
                {
                    Monitor.Exit(XXX_Conn.SerialPortLockObject);
                    // Debug.WriteLine("SerialOperationTimer " + name + ": released serial lock");
                }
                workerAlreadyEntered = false;
            }
        }
        public void Start()
        {
            Debug.Assert(Form1.GUIthreadHashcode == Thread.CurrentThread.GetHashCode()); // should ONLY be called from GUI thread
            Debug.Assert(!timer.Enabled); // successive Start or Stop calls are BAD
            Debug.WriteLine("SerialOperationTimer " + name + ": Start");
            if (runningTimer != null)
            {
                Debug.Assert(false); // Lets have a look in the debugger NOW
                throw new System.Exception("SerialOperationTimer " + name + ": Attempted 'Start' while " + runningTimer.name + " is still running");
            }
            // Start background processing
            // Release GUI thread's lock on the serial port, so background thread can grab it
            Monitor.Exit(XXX_Conn.SerialPortLockObject);
            runningTimer = this;
            timer.Enabled = true;
        }
        public void Stop()
        {
            Debug.Assert(Form1.GUIthreadHashcode == Thread.CurrentThread.GetHashCode()); // should ONLY be called from GUI thread
            Debug.Assert(timer.Enabled); // successive Start or Stop calls are BAD
            Debug.WriteLine("SerialOperationTimer " + name + ": Stop");
            if (runningTimer != this)
            {
                Debug.Assert(false); // Lets have a look in the debugger NOW
                throw new System.Exception("SerialOperationTimer " + name + ": Attempted 'Stop' while not running");
            }
            // Stop further background processing from being initiated,
            timer.Enabled = false; // but, background processing may still be in progress from the last timer tick...
            runningTimer = null;
            // Purge serial input and output buffers. Clearing input buf causes any blocking read in progress in background thread to throw
            //   System.IO.IOException "The I/O operation has been aborted because of either a thread exit or an application request.\r\n"
            if(Form1.xxConnection.PortIsOpen) Form1.xxConnection.CiCommDiscardBothBuffers();
            bool lockTaken = false;
            // Now, GUI thread needs the lock back.
            // 3 sec REALLY should be enough time for background thread to cleanup and release the lock:
            Monitor.TryEnter(XXX_Conn.SerialPortLockObject, 3000, ref lockTaken);
            if (!lockTaken)
                throw new Exception("Serial port lock not yet released by background timer thread "+name);
            if (Form1.xxConnection.PortIsOpen)
            {
                // Its possible there's still stuff in transit from device (for example, background thread just completed
                // sending an ACQ command as it was stopped). So, sync up with the device...
                int r = Form1.xxConnection.CiSync();
                Debug.Assert(r == XXX_Conn.CI_OK);
                if (r != XXX_Conn.CI_OK)
                    throw new Exception("Cannot re-sync with device after disabling timer thread " + name);
            }
        }
        /// <summary> SerialOperationTimer.StopAllBackgroundTimers() - Stop all background activity </summary>
        public static void StopAllBackgroundTimers()
        {
            if (runningTimer != null) runningTimer.Stop();
        }
        public double Interval
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }
    } // class SerialOperationTimer
