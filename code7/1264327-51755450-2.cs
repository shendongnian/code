    [TestMethod]
    public void TestWidgetDoSomething()
    {            
    	//arrange
    	TelemetryClient mockTelemetryClient = this.InitializeMockTelemetryChannel();
    	MyWidget widget = new MyWidget(mockTelemetryClient);
    
    	//act
    	var result = widget.DoSomething();
    
    	//assert
    	Assert.IsTrue(result != null);
    	Assert.IsTrue(result.IsSuccess);
    }
