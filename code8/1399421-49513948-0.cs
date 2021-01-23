    [assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
    namespace MyApp.Droid.Renderer
    {
        public class CustomNavigationRenderer : NavigationPageRenderer
        {
            public CustomNavigationRenderer(Context context) : base(context)
            {
            }
            protected override Task<bool> OnPushAsync(Page view, bool animated)
            {
                NavigationPage.SetHasNavigationBar(view, false);
                return base.OnPushAsync(view, animated);
            }                    
        }
    }
