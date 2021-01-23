    private void StartupAction()
    { 
        System.Threading.Timer infamousTimer;
        infamousTimer = new System.Threading.Timer(new TimerCallback(runMeEveryHour), null, new TimeSpan(0), new TimeSpan(1, 0, 0));
    }
