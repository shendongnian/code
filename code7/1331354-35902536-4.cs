    interface ITrackingService
	{
		void CreateEvent(string eventName, string title, string message, params object[] additionalParams);
		// ...
	} 
    // call:
    tracking.CreateEvent("Event", "Publish Event", "Publish Event From First View Model", 123);
