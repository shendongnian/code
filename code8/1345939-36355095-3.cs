    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace CustomControls_WinX86
    {
        /// <summary>
        /// Interaction logic for DoubleInput.xaml
        /// </summary>
        public partial class DoubleInput : UserControl
        {
    
    
            public double Value
            {
                get { return (double)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(double), typeof(DoubleInput), new PropertyMetadata(0d));
    
            public double Interval
            {
                get { return (double)GetValue(IntervalProperty); }
                set { SetValue(IntervalProperty, value); }
            }
            public static readonly DependencyProperty IntervalProperty =
                DependencyProperty.Register("Interval", typeof(double), typeof(DoubleInput), new PropertyMetadata(.1d));
    
            public DoubleInput()
            {
                InitializeComponent();
            }
    
            private void UpButton_Click(object sender, RoutedEventArgs e)
            {
                Value += Interval;
            }
    
            private void DownButton_Click(object sender, RoutedEventArgs e)
            {
                Value -= Interval;
            }
        }
    
        [ValueConversion(typeof(Double), typeof(String))]
        public class DoubleToStringValueConverter : IValueConverter
        {
            public object Convert(object value,
                                  Type targetType,
                                  object parameter,
                                  System.Globalization.CultureInfo culture)
            {
                decimal display = Math.Round(System.Convert.ToDecimal((double)value), 10) / 1.000000000000000000000000000000000m;
                value = System.Convert.ToDouble(display);
                string res = display.ToString(culture);
    
                return res;
            }
    
            public object ConvertBack(object value,
                                      Type targetType,
                                      object parameter,
                                      System.Globalization.CultureInfo culture)
            {
                string val = value as string;
                double res = 0d;
                double.TryParse(val, System.Globalization.NumberStyles.Float, culture, out res);
    
                return res;
            }
        }
    }
