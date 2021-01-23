    public Task FirstStep()
    {
         return Task.Run(/* whatever */);
    }
    public static Task SecondStep (this Task previousStep)
    {
        return previousStep.ContinueWith(task => { /* whatver */  };
    }
