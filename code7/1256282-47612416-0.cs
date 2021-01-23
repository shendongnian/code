    Schedule(() => FailSagaOnRequestsTimeout, x => x.CheckToken, x =>
    {
    	// timeout for all requests
    	x.Delay = TimeSpan.FromMinutes(10);
    	x.Received = e => e.CorrelateById(context => context.Message.CorrelationId);
    });
    	
    	
    During(Active,
    	When(Xxx)
    		.ThenAsync(async context =>
    		{
    			await context.Publish(context => new MyRequestCommand(context.Instance, "foo"));
    			await context.Publish(context => new MyRequestCommand(context.Instance, "bar"));
    			
    			context.Instance.WaitingMyResponsesTimeoutedAt = DateTime.UtcNow + FailSagaOnRequestsTimeout.Delay;
    			context.Instance.WaitingMyResponsesCount = 2;
    		})
    		.TransitionTo(WaitingMyResponses)
    		.Schedule(FailSagaOnRequestsTimeout, context => new FailSagaCommand(context.Instance))
    	);
    
    During(WaitingMyResponses,
    	When(MyRequestDone)
    		.Then(context =>
    		{
    			if (context.Instance.WaitingMyResponsesTimeoutedAt < DateTime.UtcNow)
    				throw new TimeoutException();
    		})
    		.If(context =>
    		{
    			var db = serviceProvider.GetRequiredService<DbContext>();
    			var requestsStates = db.MyRequestStates.Where(x => x.ParentSagaId == context.Instance.CorrelationId).Select(x => x.State).ToList();
    			var allDone = requestsStates.Count == context.Instance.WaitingMyResponsesCount &&
    				requestsStates.All(x => x != nameof(MyRequestStateMachine.Processing)); // assume 3 states of request - Processing, Done and Failed
    			return allDone;
    		}, x => x
    			.Unschedule(FailSagaOnRequestsTimeout)
    			.TransitionTo(Active))
    		.Catch<TimeoutException>(x => x.TransitionTo(Failed));
    		
    During(WaitingMyResponses,
    	When(FailSagaOnRequestsTimeout.Received)
    		.TransitionTo(Failed)
		
