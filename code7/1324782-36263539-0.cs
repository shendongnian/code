    /// <summary>
    /// holds the message being send to the listener
    /// </summary>
    public class DetailedProgressEventArgs:EventArgs
    {
        public string Message;
        public DetailedProgressEventArgs(string msg)
        {
            Message = msg;
        }
    }
    
    /// <summary>
    /// enables sending events when a log message is written
    /// </summary>
    /// <param name="sender">the instance that sends the event</param>
    /// <param name="e">the actual message</param>
    public delegate void DetailedProgressEventHandler(object sender, DetailedProgressEventArgs e);
    
    /// <summary>
    /// Used as a TraceListener and wired in the app.config to receive System.Net messages
    /// </summary>
    public class DetailedProgressListener : TraceListener
    {
        // wire the event handlers here
        static public event DetailedProgressEventHandler ProgressChanged;
    
        public override void Write(string message)
        {
            // let's do nothing
        }
    
        /// <summary>
        /// rasies a progessChanged event for every message
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message)
        {
            var pch = ProgressChanged;
            if (pch!=null)
            {
                pch.Invoke(this, new DetailedProgressEventArgs(message));
            }
        }
    }
