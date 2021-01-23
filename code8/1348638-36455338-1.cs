    public async Task Only_Publish_Incomplete_Models_After_Receiving_Request()
    {
    	var gateway = MockComponentModelGateway;
    	gateway.SetMessageBus(messageBus);
    	
    
    	var defaultTimeout = TimeSpan.FromMilliseconds(1000);
    	var scheduler = new TestScheduler();
    
    
    	// GIVEN a component model gateway and an incomplete model update.
    	var modelUpdate = new Model { IntProperty = 1, BoolProperty = null };
    	Assert.False(modelUpdate.IsComplete);
    
    	scheduler.Schedule(TimeSpan.FromMilliseconds(100),() => {
    		messageBus.Publish(new ModelUpdateEventMessage(modelUpdate));
    	});
    
    	scheduler.Schedule(TimeSpan.FromMilliseconds(200),() =>
    	{
    		messageBus.Publish(new ModelQueryRequestedEventMessage());
    	});
    
    	var observer = scheduler.CreateObserver<Model>();
    
    	myObservable.Subscribe(observer);
    	
    	scheduler.Start();
    
    	CollectionAssert.AreEqual(
    		new[]{
    			ReactiveTest.OnNext(TimeSpan.FromMilliseconds(200).Ticks, modelUpdate)
    		},
    		observer.Messages);
    }
