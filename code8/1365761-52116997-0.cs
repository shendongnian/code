    [assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationRenderer))]
    
    namespace App.Droid
    {
        public class CustomNavigationRenderer : NavigationPageRenderer
        {
    
            public CustomNavigationRenderer(Context context) : base(context)
            {
            }
    
            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {
                base.OnLayout(changed, l, t, r, b);
                var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
                for (var i = 0; i < toolbar.ChildCount; i++)
                {
                    var imageButton = toolbar.GetChildAt(i) as ImageButton;
    
                    var hamburger = imageButton?.Drawable as DrawerArrowDrawable;
                    if (hamburger == null)
                        continue;
    
                    hamburger.Color = Context.GetColor(Resource.Color.primary_text_default_material_light);
                    hamburger.Alpha = 255;
                }
    
    
            }
        }
    }
