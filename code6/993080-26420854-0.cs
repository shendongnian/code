    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    
    namespace WpfStackOverflowSample
    {
        public static class ButtonBehavior
        {
            private static readonly DependencyProperty ImgSourceProperty = DependencyProperty.RegisterAttached(
                "ImgSource", 
                typeof (ImageSource), 
                typeof (ButtonBehavior), 
                new PropertyMetadata(default(ImageSource)));
    
            public static void SetImgSource(ButtonBase button, ImageSource value)
            {
                button.SetValue(ImgSourceProperty, value);
            }
    
            public static ImageSource GetImgSource(ButtonBase button)
            {
                return (ImageSource)button.GetValue(ImgSourceProperty);
            }
            
        }
    }
