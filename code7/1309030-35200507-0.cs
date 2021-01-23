    public sealed partial class MyUserControl : UserControl
    {
        public Color BackgroundColor
        {
            get { return ((SolidColorBrush)Background).Color; }
            set { Background = new SolidColorBrush(value); }
        }
    }
