    public class BaseForm : ContentPage
    	{
    		public BaseForm () : base () { }
    
    		protected override void OnAppearing ()
    		{
    			base.OnAppearing ();
    
    			AnalyticsApi.LogPageView ();
                AnalyticsApi.LogEvent(Title + " Page Loaded");
    		}
    	}
