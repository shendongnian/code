     public class TimeRangeSlider : Control
    {
        private const string PartName_LowerSlider = "Part_LowerSlider";
        private const string PartName_UpperSlider = "Part_UpperSlider";
        private const string PartName_SelectedRegion = "Part_SelectedRect";
        private const string PART_RIGHTTHUMPVALUE = "PART_RIGHTTHUMPVALUE";
        private Slider lowerSlider;
        private Slider upperSlider;
        Rectangle selectedRect;
        TextBlock rightText;
        public TimeRangeSlider()
        {
            this.DefaultStyleKey = typeof(TimeRangeSlider);
            this.Loaded += TimeRangeSlider_Loaded;
        }
        void TimeRangeSlider_Loaded(object sender, RoutedEventArgs e)
        {
            lowerSlider.ValueChanged += LowerSlider_ValueChanged;
            upperSlider.ValueChanged += UpperSlider_ValueChanged;
            lowerSlider.Minimum = Minimum;
            lowerSlider.Maximum = Maximum;
            lowerSlider.Value = LowerValue;
            upperSlider.Minimum = Minimum;
            upperSlider.Maximum = Maximum;
            upperSlider.Value = UpperValue;
            SetView();
        }
        public override void OnApplyTemplate()
        {
            lowerSlider = this.GetTemplateChild(PartName_LowerSlider) as Slider;
            upperSlider = this.GetTemplateChild(PartName_UpperSlider) as Slider;
            selectedRect = this.GetTemplateChild(PartName_SelectedRegion) as Rectangle;
            rightText = this.GetTemplateChild(PART_RIGHTTHUMPVALUE) as TextBlock;
            base.OnApplyTemplate();
        }
        private void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            upperSlider.Value = Math.Max(upperSlider.Value, lowerSlider.Value);
            SetView();
        }
        private void UpperSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lowerSlider.Value = Math.Min(upperSlider.Value, lowerSlider.Value);
            SetView();
        }
        private void SetView()
        {
            LowerValue = lowerSlider.Value;
            UpperValue = upperSlider.Value;
            var unit = lowerSlider.ActualWidth / Maximum;
            var leftMargin = LowerValue * unit;
            if (UpperValue > LowerValue)
            {
                var width = (UpperValue - LowerValue) * unit;
                selectedRect.Width = width;
            }
            selectedRect.Margin = new Thickness(leftMargin, 0, 0, 0);
            rightText.Margin = new Thickness(selectedRect.Width-20, 0, 0, 0);
        }
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(TimeRangeSlider), new UIPropertyMetadata(0d));
        public double LowerValue
        {
            get { return (double)GetValue(LowerValueProperty); }
            set { SetValue(LowerValueProperty, value); }
        }
        public static readonly DependencyProperty LowerValueProperty =
            DependencyProperty.Register("LowerValue", typeof(double), typeof(TimeRangeSlider), new UIPropertyMetadata(0d));
        public double UpperValue
        {
            get { return (double)GetValue(UpperValueProperty); }
            set { SetValue(UpperValueProperty, value); }
        }
        public static readonly DependencyProperty UpperValueProperty =
            DependencyProperty.Register("UpperValue", typeof(double), typeof(TimeRangeSlider), new UIPropertyMetadata(0d));
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(TimeRangeSlider), new UIPropertyMetadata(1d));
    }
