    namespace App1
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
                this.NavigationCacheMode = NavigationCacheMode.Required;
    
                SimpleOrientationSensor.GetDefault().OrientationChanged += (s, a) =>
                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        if (a.Orientation == SimpleOrientation.NotRotated || a.Orientation == SimpleOrientation.Faceup || a.Orientation == SimpleOrientation.Facedown)
                        {
                            media.IsFullWindow = false;
                        }
                        else
                        {
                            media.IsFullWindow = true;
                        }
                    });
            }
        }
    }
