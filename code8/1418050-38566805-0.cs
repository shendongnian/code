    public class ThumbConverter : DependencyObject, IValueConverter
    {
        public double SecondValue
        {
            get { return (double)GetValue(SecondValueProperty); }
            set { SetValue(SecondValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SecondValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondValueProperty =
            DependencyProperty.Register("SecondValue", typeof(double), typeof(ThumbConverter), new PropertyMetadata(0d));
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // assuming you want to display precentages
            return $"Precentage: {double.Parse(value.ToString()) / SecondValue}";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
