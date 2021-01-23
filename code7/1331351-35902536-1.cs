	public static class GoogleAnalyticsWrapper
	{
		static void Initialize(IMvxMessenger messenger)
		{
			Gai.SharedInstance.DispatchInterval = 60;
			Gai.SharedInstance.TrackUncaughtExceptions = true;
			Gai.SharedInstance.GetTracker(TrackingId); 
			screenNameToken = messenger.Subscribe<GaScreenNameMessage>((m) => SetScreenName(m));
			int count = messenger.CountSubscriptionsFor<GaScreenNameMessage>();
			eventToken = messenger.Subscribe<GaEventMessage>(CreateEvent);
			exceptionToken = messenger.Subscribe<GaExceptionMessage>(CreateException);
			performanceToken = messenger.Subscribe<GaPerformanceTimingMessage>(CreatePerformanceMetric);
			publishToken = messenger.Subscribe<GaPublishMessage>(PublishAll);
		}
		
		// ...
	}	
