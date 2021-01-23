    class MultiBindingViewModel : DependencyObject
    {
        public static readonly DependencyProperty PropertiesProperty = DependencyProperty.Register(
            "Properties", typeof(Tuple<double, double>), typeof(MultiBindingViewModel), new PropertyMetadata(null, OnPropertyChanged);
        public static readonly DependencyProperty PropertySelectorProperty = DependencyProperty.Register(
            "PropertySelector", typeof(bool), typeof(MultiBindingViewModel), new PropertyMetadata(null, OnPropertyChanged);
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(double), typeof(MultiBindingViewModel), null);
        public Tuple<double, double> Properties
        {
            get { return (Tuple<double, double>)GetValue(PropertiesProperty); }
            set { SetValue(PropertiesProperty, value); }
        }
        public bool PropertySelector
        {
            get { return (bool)GetValue(PropertySelectorProperty); }
            set { SetValue(PropertySelectorProperty, value); }
        }
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiBindingViewModel model = (MultiBindingViewModel)d;
            d.Value = d.PropertySelector ? d.Properties.Item1 : d.Properties.Item2;
        }
    }
