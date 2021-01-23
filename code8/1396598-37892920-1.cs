    [assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationPage))]
    namespace CustomNavigationPage.iOS
    {
    	public class CustomNavigationPage : NavigationRenderer
    	{
    		protected override void OnElementChanged(VisualElementChangedEventArgs e)
    		{
    			base.OnElementChanged(e);
    
    			NavigationBar.SetBackgroundImage(new UIKit.UIImage(), UIKit.UIBarMetrics.Default);
    			NavigationBar.ShadowImage = new UIKit.UIImage();
    		}
    	}
    }
