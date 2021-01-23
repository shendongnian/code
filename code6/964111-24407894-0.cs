    var mockZincContainer = new Mock<IContainer>();
  
    // works just fine
    mockZincContainer.Object.Resolve<DateTime>(); // returns default(DateTime)
	mockZincContainer.Object.Resolve<object>(); // returns default(object)
