    public class isQuestionResponseNullConverter : DependencyObject, IValueConverter
    {
        public object Parameter
        {
            get { return (object)GetValue(ParameterProperty); }
            set { SetValue(ParameterProperty, value); }
        }
        public static readonly DependencyProperty ParameterProperty =
            DependencyProperty.Register("Parameter", typeof(object), typeof(isQuestionResponseNullConverter), new PropertyMetadata(null));
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            IResponse response = (IResponse)value;
            if (response == null)
            {
                return false;
            }
            return true;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value == true)
            {
                return Parameter; //Get Parameter
            }
            else
            {
                return null;
            }
        }
    }
