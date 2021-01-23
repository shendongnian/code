    public class CustomNavigationRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged (e);
    
            var actionBar = ((Activity)Context).ActionBar;
            actionBar.SetIcon (Resource.Color.Transparent);
        }
    }
