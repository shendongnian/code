    public class DragDropTimer
    {
        private delegate void DoDragDropDelegate();
        private System.Timers.Timer dragTimer;
        private readonly int interval = 3000;
    
        public DragDropTimer()
        {
            dragTimer = new System.Timers.Timer();
            dragTimer.Interval = interval;
            dragTimer.Elapsed += new ElapsedEventHandler(DragDropTimerElapsed);
            dragTimer.Enabled = false;
            dragTimer.AutoReset = false;
        }
    
        void DragDropTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Initiate();
        }
    
        public void Initiate()
        {
            // Stops UI from freezing, call action async.
            DoDragDropDelegate doDragDrop = new DoDragDropDelegate(DragDropAction);
    
            // No async callback or object required
            doDragDrop.BeginInvoke(null, null);
        }
    
        private void DragDropAction()
        {
            dragTimer.Enabled = false; 
    
            // Do your work here. or do work before and disable your timer upto you.
        }
    
    }
