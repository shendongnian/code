    [assembly:ExportRenderer (typeof(NavigationPage), typeof(NavigationPageRenderer))]
    namespace SuperForms.Samples.Droid
    {
        public class NavigationPageRenderer : NavigationRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
            {
                base.OnElementChanged(e);
                var actionBar = ((Activity)Context).ActionBar;
                actionBar.SetIcon(Resource.Drawable.newIcon);
            }
        }
    }
