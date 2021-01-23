    [Test]
    [Category("Simple Basic Tests")]
    public void SubscribesToMonitoringRequets_requestPublished_FilterEventTypeCalled()
    {
        //mock of event aggregator and the request event dependencies of monitoring service
        var mockEventAggregator = new Mock<IEventAggregator>();
        var mockMonitoringRequestedEvent = new Mock<MonitoringRequestGenerated>();
        var mockDependecy = new Mock<IDependency>();
        mockEventAggregator.Setup(x => x.GetEvent<MonitoringRequestGenerated>())
                .Returns(mockMonitoringRequestedEvent.Object);
        Action<List<MonitoringRequest>> callbackMethod = null;
        mockMonitoringRequestedEvent
                .Setup(
                    x => x.Subscribe(
                        It.IsAny<Action<List<MonitoringRequest>>>(),
                        It.IsAny<ThreadOption>(),
                        It.IsAny<bool>(),
                        It.IsAny<Predicate<List<MonitoringRequest>>>()))
                .Callback<Action<List<MonitoringRequest>>, ThreadOption, bool, Predicate<List<MonitoringRequest>>>(
                    (a, t, b, p) => callbackMethod = a);
        var testFzrteMonitoringService = new FzrteMonitoringService(
                mockEventAggregator.Object, mockDependecy.Object);
        //use the actual  event aggregator to publish
        var mockMonitoringRequestEventPayload = new Mock<List<MonitoringRequest>>();
        mockEventAggregator.Object
                .GetEvent<MonitoringRequestGenerated>()
                .Publish(mockMonitoringRequestEventPayload.Object);
        mockMonitoringRequestedEvent.Verify(
                x => x.Subscribe(testFzrteMonitoringService.FilterEventType));
    }
