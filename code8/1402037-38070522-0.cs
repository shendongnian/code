    public async void Run(IBackgroundTaskInstance taskInstance)
    {
        var smsDetails	= taskInstance.TriggerDetails as SmsMessageReceivedTriggerDetails;
        	
        // consume sms
        var from = smsDetails.TextMessage.From;
        var body = smsDetails.TextMessage.Body;
        
        // we acknoledege the reception of the message
        smsDetails.Accept();
    }
    static IBackgroundTaskRegistration Register()
    {
        var taskNameAndEntryPoint	= typeof(SmsInterceptor).FullName;
        
        var task = BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault(x => x.Name == taskNameAndEntryPoint);
        if(task != null) return task;
        			
        var filterRule		= new SmsFilterRule(SmsMessageType.App);
        filterRule.SenderNumbers.Add("111111111");
        filterRule.SenderNumbers.Add("222222222");
        
        var filterRules				= new SmsFilterRules(SmsFilterActionType.AcceptImmediately);
        filterRules.Rules.Add(filterRule);
        
        var taskBuilder				= new BackgroundTaskBuilder();
        taskBuilder.Name			= taskNameAndEntryPoint;
        taskBuilder.TaskEntryPoint	= taskNameAndEntryPoint;
        taskBuilder.SetTrigger(new SmsMessageReceivedTrigger(filterRules));
        return taskBuilder.Register();
    }
