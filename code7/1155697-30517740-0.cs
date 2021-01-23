    lock (this)
                {
                    var dispatcherOp = Application.Current.Dispatcher.BeginInvoke(MyAction, DispatcherPriority.Normal);
                    dispatcherOp.Completed += dispatcherOp_Completed;
                }
  
    void dispatcherOp_Completed(object sender, EventArgs e)
            {
                lock (this)
                {
    
                }
                
            }
