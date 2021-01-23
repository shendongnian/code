    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;
    namespace EdPlunkett
    {
        public class GreaterThan : MarkupExtension, IValueConverter
        {
            public GreaterThan(double opnd)
            {
                Operand = opnd;
            }
            /// <summary>
            /// Converter returns true if value is greater than this.
            /// </summary>
            public double Operand { get; set; }
            //  When the XAML is parsed, each markup extension is instantiated 
            //  and the parser asks it to provide its value. Here, the value is 
            //  us. 
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return System.Convert.ToDouble(value) > Operand;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
