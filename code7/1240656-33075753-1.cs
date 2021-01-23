    [assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(BlueNavigationRenderer))]
        namespace MobileCRM.iOS.Renderers
        {
            public class BlueNavigationRenderer : NavigationRenderer
            {
    
                public override void ViewDidLoad()
                {
                    base.ViewDidLoad();
    
                    this.NavigationBar.BarTintColor = UIColor.FromPatternImage(UIImage.FromFile("topbar_bg@2x.png"));
                 }
              }
         }
