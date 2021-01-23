    async Task DoWorkAsync()
    {
        IoC.Get<IEventAggregator>()
             .PublishOnUIThread(new ShowWaitingAnimationArgs
             {
                 DisplayMessage = "Updating database file...",
                 ShowWaitingAnimation = true
             });
         
        var resultList = await Task.Run(
            () => update.HandledDifferences(testContext, realContext, imo));
        IoC.Get<IEventAggregator>()
            .PublishOnUIThread(new ShowWaitingAnimationArgs {ShowWaitingAnimation = false});
         
        return ResultList;
    }
