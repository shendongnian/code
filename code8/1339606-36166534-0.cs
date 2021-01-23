    private void StartupAction()
    { 
        System.Threading.Timer infamousTimer;
        infamousTimer = new System.Threading.Timer(new TimerCallback(runMeEveryHour), null, new TimeSpan(0), new TimeSpan(1, 0, 0));
        while(true) { Thread.Sleep(1000); } //this is the simplest logic to keep the thread alive
    }
