    public partial class YourUserControl : UserControl
    {
        ...
        public Brush XBackground
        {
            get { return (Brush)GetValue(XBackgroundProperty); }
            set { SetValue(XBackgroundProperty, value); }
        }
        public static readonly DependencyProperty XBackgroundProperty =
            DependencyProperty.Register(
                "XBackground",
                typeof(Brush),
                typeof(YourUserControl),
                new PropertyMetadata(null, XBackgroundPropertyChanged));
        private static void XBackgroundPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (YourUserControl)obj;
            userControl.expander.Background = (Brush)e.NewValue;
        }
    }
