    protected override void Initialize()
    {
        events = application.Events;
        buildEvents = events.BuildEvents;
        publishEvents = events.PublishEvents;
        buildEvents.OnBuildBegin += this.OnBuildBegin;
        publishEvents.OnPublishBegin += this.OnPublishBegin;
    }
    
    private Events2 events;
    private BuildEvents buildEvents;
    private PublishEvents publishEvents;
