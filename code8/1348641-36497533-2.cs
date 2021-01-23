	[Theory]
	[PairwiseData]
	public async Task Adapted_Component_Model_Gateway_Should_Publish_Current_Model_When_Requested(
		[CombinatorialValues(null, 1, 2)] int? intValue,
		[CombinatorialValues(null, true, false)] bool? boolValue)
	{
		var model = new AllowStaleDetailsMockModel { IntProperty = intValue, BoolProperty = boolValue };
		if (model.IsComplete) return;
		// GIVEN an initialized adapted component model gateway and a given _INCOMPLETE_ current model.
		var adaptedGateway = AdaptGateway(MockComponentModelGateway);
		adaptedGateway.SetMessageBus(messageBus);
		adaptedGateway.Initialize();
		// EXPECT no current model is published after publishing the incomplete model update.
		var messagePublished = allowStaleCurrentModelObservable.BufferEmissions().ContainsEvents();
		messageBus.Publish(new CurrentModelUpdateReadyEventArgs<AllowStaleDetailsMockModel>(model));
		Assert.False(await messagePublished);
		// WHEN we publish a current model query.
		var actualModel = allowStaleCurrentModelObservable.WaitForEmission();
		messageBus.Publish(new CurrentModelQueryRequestedEventArgs());
		// THEN the current model should be published.
		Assert.Equal(model, await actualModel);
	}
