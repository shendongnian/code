    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace MultiBindingConverterDemo
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        public class MultiplyValueConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                double height = (double)value;
                double multiplier = double.Parse((string)parameter);
                return new Thickness(height * multiplier);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
