    public class ImageTextButton : Button
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof (ImageSource), typeof (ImageTextButton), null);
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof (string), typeof (ImageTextButton), null);
        public ImageTextButton()
        {
            this.DefaultStyleKey = typeof(ImageTextButton);
        }
        public ImageSource Icon
        {
            get { return (ImageSource) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
