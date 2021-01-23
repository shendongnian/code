    private static Timer timer = new Timer(TimerCallback, null, 5000, 5000);
    private static DispatcherOperation dispatcherOperationPrevious = null;
    private static void TimerCallback(object state)
    {
        DispatcherOperation dispatcherOperation = 
 
        // Dispatcher here is using the controls dispatcher, the BeginInvoke is not a static method.. (like you probably assumed..
        // So calling the BeginInvoke of the controls property 'Dispatcher'
        Dispatcher.BeginInvoke(new Action(() =>
        {
            Debug.Print("Pass here at: " + DateTime.Now.ToString("O"));
        }));
        dispatcherOperationPrevious = dispatcherOperation;
    }
