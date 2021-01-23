	interface ITrackingService
	{  
		void SetScreenName(GaScreenNameMessage message);
		void CreateEvent(GaEventMessage message);
		void CreateException(GaExceptionMessage message);
		void CreatePerformanceMetric(GaPerformanceTimingMessage message);
		void PublishAll(GaPublishMessage message);
	}
	public class GoogleAnalyticsTrackingService : ITrackingService
	{
		private const string TrackingId = "xxxxxxxxxxx";
		public GoogleAnalyticsTrackingService()
		{
			Gai.SharedInstance.DispatchInterval = 60;
			Gai.SharedInstance.TrackUncaughtExceptions = true;
			Gai.SharedInstance.GetTracker(TrackingId);
		}
		
		public void SetScreenName(GaScreenNameMessage message) 
		{
			Gai.SharedInstance.DefaultTracker.Set(GaiConstants.ScreenName, message.ScreenName);
			Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateScreenView().Build());
		}
		public void CreateEvent(GaEventMessage message) 
		{
			Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateEvent(message.Category, message.Action, message.Label, message.Number).Build());
		}	
		private void CreateException(GaExceptionMessage message) 
		{
			Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateException(message.ExceptionMessage, message.IsFatal).Build());
		}
		private void CreatePerformanceMetric(GaPerformanceTimingMessage message)
		{
			Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateTiming(message.Category, message.Milliseconds, message.Name, message.Label).Build());
		}
		private void PublishAll(GaPublishMessage message) 
		{
			Gai.SharedInstance.Dispatch();
		}
	}
