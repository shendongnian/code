    using Foundation;
    using UIKit;
    
    namespace MyApp.iOS
    {
    	[Register("AppDelegate")]
    	public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    	{
    		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
    		{
    			global::Xamarin.Forms.Forms.Init();
    			LoadApplication(new App());
    			var result = base.FinishedLaunching(uiApplication, launchOptions);
    
    			uiApplication.KeyWindow.TintColor = UIColor.Blue;
    
    			return result; 
    		}
    	}
    }
