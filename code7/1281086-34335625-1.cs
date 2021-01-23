    var journey = new Journey 
    { 
        SessionId = sessionId, 
        ConveyancingAnswer = new Collection<ConveyancingAnswer>()
    };
    var journeys = new List<Journey> { journey };  
    mockedDbContext.Setup(o => o.Journey)
                   .Returns(() => TestExtensionMethods.AsDbSet<Journey>(journeys));
