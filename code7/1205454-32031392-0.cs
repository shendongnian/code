    IoC.Get<IEventAggregator>()
             .PublishOnUIThread(new ShowWaitingAnimationArgs
             {
                 DisplayMessage = "Updating database file...",
                 ShowWaitingAnimation = true
             });
    		 
    	using (var A = AsyncHelper.Wait)
        {
            A.Run(update.HandledDifferences(testContext, realContext, imo), res => ResultList = res);
        }
    	
        IoC.Get<IEventAggregator>()
                 .PublishOnUIThread(new ShowWaitingAnimationArgs {ShowWaitingAnimation = false});
    			 
         return ResultList;
