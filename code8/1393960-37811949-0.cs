    public class CustomTextBox : TextBox
    {
        public static readonly DependencyProperty ImageSrcProperty =
            DependencyProperty.Register(
               "ImageSrc", typeof(ImageSource), typeof(CustomTextBox));
        public ImageSource ImageSrc
        {
            get { return (ImageSource)GetValue(ImageSrcProperty); }
            set { SetValue(ImageSrcProperty, value); }
        }
    }
