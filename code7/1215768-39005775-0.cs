    public partial class UICustomTabBar : UITabBar
    {
        public UICustomTabBar (IntPtr handle) : base (handle)
        {
            //Set your colors
            BackgroundColor = UIColor.White;
            SelectedImageTintColor = UIColor.Red;
            foreach (UITabBarItem tabBarItem in Items)
            {
                tabBarItem.SelectedImage = tabBarItem.SelectedImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                tabBarItem.Image = tabBarItem.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
        }
    }
