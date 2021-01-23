    [assembly: ExportRenderer(typeof(ContentPage), typeof(ContentPageRenderer))]
        namespace MyApp.Renderers
        {
            public class ContentPageRenderer : PageRenderer
            {
                protected override void OnLayout(bool changed, int l, int t, int r, int b)
                {
                        base.OnLayout(changed, l, t, r, b);
                        var actionBar = ((Activity)Context).ActionBar;
                        actionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.YourImageInDrawable));
                }
            }
        }
