	[Test]
	public async Task MyTest1()
	{
		var readyToScheduleQuery = new ReadyToScheduleQuery()
		{
			Facets = new List<Facet>() {  new Facet() {  Name = "Service Type", Values = new List<FacetValue>() {  new FacetValue() {  Value = "SomeJob", Selected = true} } } }                 
		};
		// missing await
		var result = await readyToScheduleQuery.ExecuteAsync(_appointmentRespositoryStub); 
		Assert.IsNotNull(result); // you will receive your actual expected unwrapped result here. test it directly, not the task.
	}
