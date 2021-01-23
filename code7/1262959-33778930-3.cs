    public sealed class MyRadioButton : RadioButton
    {
        public MyRadioButton()
        {
            this.DefaultStyleKey = typeof(MyRadioButton);
            UnCheckedBrush = new SolidColorBrush(Colors.Transparent);
            CheckedBrush = new SolidColorBrush(Colors.Red);
            this.Checked += (sender, args) =>
            {
                this.CustomBackground = CheckedBrush;
            };
            this.Unchecked += (sender, args) =>
            {
                this.CustomBackground = UnCheckedBrush;
            };
        }
        public static readonly DependencyProperty CustomBackgroundProperty = DependencyProperty.Register(
            "CustomBackground", typeof (Brush), typeof (MyRadioButton), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty CheckedBrushProperty = DependencyProperty.Register(
            "CheckedBrush", typeof(Brush), typeof(MyRadioButton), new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty UnCheckedBrushProperty = DependencyProperty.Register(
            "UnCheckedBrush", typeof(Brush), typeof(MyRadioButton), new PropertyMetadata(default(Brush)));
        public Brush CustomBackground
        {
            get { return (Brush) GetValue(CustomBackgroundProperty); }
            set { SetValue(CustomBackgroundProperty, value); }
        }
        
        public Brush CheckedBrush
        {
            get { return (Brush) GetValue(CheckedBrushProperty); }
            set { SetValue(CheckedBrushProperty, value); }
        }
        public Brush UnCheckedBrush
        {
            get { return (Brush) GetValue(UnCheckedBrushProperty); }
            set { SetValue(UnCheckedBrushProperty, value); }
        }
    }
