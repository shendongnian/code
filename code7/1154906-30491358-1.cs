    public class FlushingAdoNetAppender : AdoNetAppender
    {
        private Timer flushTimer;
        private TimeSpan flushInterval = TimeSpan.FromMinutes(5);
    
        public FlushingAdoNetAppender()
        {
            // Enable for debugging purposes
            // LogLog.InternalDebugging = true;
        }
    
        public TimeSpan FlushInterval
        {
            /* 
            
            The interval after which the buffer will be flushed. Defaults to 5 minutes
            
            Example config:
    
            <appender name="DatabaseAppender" type="Your.Namespace.FlushingAdoNetAppender">
                <flushInterval value="00:30:00" />
            </appender>
    
            */
    
            get { return flushInterval; }
            set { flushInterval = value; }
        }
    
        public override void ActivateOptions()
        {
            flushTimer = new Timer(flushInterval.TotalMilliseconds);
    
            LogLog.Debug(GetType(), "Flush timer interval is " + TimeSpan.FromMilliseconds(flushTimer.Interval));
    
            flushTimer.Enabled = true;
            flushTimer.Elapsed += FlushLog;
            flushTimer.Start();
    
            base.ActivateOptions();
        }
    
        protected override void OnClose()
        {
            // This is called by log4net when reloading the config
            flushTimer.Stop();
            flushTimer.Dispose();
            base.OnClose(); // calls Flush()
        }
    
        private void FlushLog(object sender, ElapsedEventArgs e)
        {
            LogLog.Debug(GetType(), "Flushing logs");
            Flush();
        }
    }
