    private void WaitParameterReceived(ParameterType param)
    {
        while (_paramsUpdated.Find(x => x.ParameterType == param).Flag)
        {
           // Do nothing
           Thread.Sleep(threadSleepTimeMS);
           //Thread.Yield();
        }
    }
