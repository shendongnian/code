    [assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationPageRenderer))]
    namespace RTW.Mobile.App.Droid.Renderers
    {
        public class CustomNavigationPageRenderer : NavigationPageRenderer, IMessageSender
        {
            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {
                base.OnLayout(changed, l, t, r, b);
    
                var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
                for (var i = 0; i < toolbar.ChildCount; i++)
                {
                    var imageButton = toolbar.GetChildAt(i) as ImageButton;
                    var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;
    
                    if (drawerArrow == null)
                        continue;
                    //ensure only one handler is registered
                    imageButton.Click -= imageButton_Click;
                    imageButton.Click += imageButton_Click;
                }
            }
    
            private void imageButton_Click(object sender, EventArgs e)
            {
                if (!App.IsBlockingConditionTrue)
                {
                    MessagingCenter.Send<IMessageSender>(this, "ToggleMasterIsPresented");
                }
            }
        }
    }
