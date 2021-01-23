      public class SliderConverter:DependencyObject,IValueConverter
    {
        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(SliderConverter), new PropertyMetadata(0));
        
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter == null)
            {
                double d = (MyProperty / 2) - (double)value;
                Debug.WriteLine(d);
                if (d < 0) return 0;
                return d*2;
            }
            else
            {
                double d = (double)value - (MyProperty / 2);
                Debug.WriteLine(d);
                if (d < 0) return 0.0;
                return d*2;
            
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
