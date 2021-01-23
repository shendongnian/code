    public partial class ColorDefiner : UserControl
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                "Color", typeof(Color), typeof(ColorDefiner),
                new FrameworkPropertyMetadata(
                    Colors.Black,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    (o, e) => ((ColorDefiner)o).ColorPropertyChanged((Color)e.NewValue)));
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public ColorDefiner()
        {
            InitializeComponent();
        }
        private void ColorPropertyChanged(Color color)
        {
            sliderA.Value = (double)color.A;
            sliderR.Value = (double)color.R;
            sliderG.Value = (double)color.G;
            sliderB.Value = (double)color.B;
        }
        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color = Color.FromArgb((byte)sliderA.Value,
                (byte)sliderR.Value, (byte)sliderG.Value, (byte)sliderB.Value);
        }
    }
