    public class BasePage : ContentPage
    	{
    		public BasePage () : base () { }
    
    		protected override void OnAppearing ()
    		{
    			base.OnAppearing ();
    
    			AnalyticsApi.LogPageView ();
                AnalyticsApi.LogEvent(Title + " Page Loaded");
    		}
    	}
