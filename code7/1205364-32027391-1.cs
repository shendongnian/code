    public class NavBarButton : Button
    {
        //Unless you override the style it will never be rendered
        static NavBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavBarButton), new FrameworkPropertyMetadata(typeof(NavBarButton)));
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        "Text",
        typeof(string),
        typeof(NavBarButton),
        new UIPropertyMetadata(null));
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
            "Image",
            typeof(ImageSource),
            typeof(NavBarButton),
            new UIPropertyMetadata(null));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
    }
