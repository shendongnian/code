    private static void TimerCallback(object state)
    {
        DispatcherOperation dispatcherOperation = 
            Application.CurrentDispatcher.BeginInvoke(new Action(() =>
        {
            Debug.Print("Pass here at: " + DateTime.Now.ToString("O"));
        }));
    
        dispatcherOperationPrevious = dispatcherOperation;
    }
