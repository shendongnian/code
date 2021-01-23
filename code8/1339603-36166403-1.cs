    private Timer infamousTimer;
    
    private void StartupAction()
    { 
        infamousTimer = new System.Threading.Timer(new TimerCallback(runMeEveryHour), null, new TimeSpan(0), new TimeSpan(1, 0, 0));
    }
