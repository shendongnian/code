    [assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
    namespace App.Droid
    {
        public class CustomNavigationRenderer : NavigationRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
            {
                base.OnElementChanged(e);
                RemoveAppIconFromActionBar();
            }
            void RemoveAppIconFromActionBar()
            {
                var actionBar = ((Activity)Context).ActionBar;
                actionBar.SetIcon(new ColorDrawable(Color.Transparent.ToAndroid()));
            }
        }
    }
