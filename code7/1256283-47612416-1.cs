    Schedule(() => CheckAllRequestsDone, x => x.CheckToken, x =>
    {
    	// check interval
    	x.Delay = TimeSpan.FromSeconds(15);
    	x.Received = e => e.CorrelateById(context => context.Message.CorrelationId);
    });
    		
    During(Active,
    	When(Xxx)
    		.ThenAsync(async context =>
    		{
    			await context.Publish(context => new MyRequestCommand(context.Instance, "foo"));
    			await context.Publish(context => new MyRequestCommand(context.Instance, "bar"));
    			
    			context.Instance.WaitingMyResponsesTimeoutedAt = DateTime.UtcNow.AddMinutes(10);
    			context.Instance.WaitingMyResponsesCount = 2;
    		})
    		.TransitionTo(WaitingMyResponses)
    		.Schedule(CheckAllRequestsDone, context => new CheckAllRequestsDoneCommand(context.Instance))
    	);
    		
    During(WaitingMyResponses,
    	When(CheckAllRequestsDone.Recieved)
    		.Then(context =>
    		{
    			var db = serviceProvider.GetRequiredService<DbContext>();
    			var requestsStates = db.MyRequestStates.Where(x => x.ParentSagaId == context.Instance.CorrelationId).Select(x => x.State).ToList();
    			var allDone = requestsStates.Count == context.Instance.WaitingMyResponsesCount &&
    				requestsStates.All(x => x != nameof(MyRequestStateMachine.Processing));
    			if (!allDone)			
    			{
    				if (context.Instance.WaitingMyResponsesTimeoutedAt < DateTime.UtcNow + CheckAllRequestsDone.Delay)				
    					throw new TimeoutException();
    				throw new NotAllDoneException();
    			}
    		})
    		.TransitionTo(Active)
    		.Catch<NotAllDoneException>(x => x.Schedule(CheckAllRequestsDone, context => new CheckAllRequestsDoneCommand(context.Instance)))
    		.Catch<TimeoutException>(x => x.TransitionTo(Failed));
