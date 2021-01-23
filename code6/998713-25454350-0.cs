    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Data;
    namespace WpfApplication1
    {
        public class SumConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                IEnumerable enumerable = value as IEnumerable;
                if (enumerable == null)
                {
                    return DependencyProperty.UnsetValue;
                }
                IEnumerable<object> collection = enumerable.Cast<object>();
                PropertyInfo property = null;
                string propertyName = parameter as string;
                if (propertyName != null && collection.Any())
                {
                    property = collection.First().GetType().GetProperty(propertyName);
                }
                return collection.Select(x => System.Convert.ToInt32(property != null ? property.GetValue(x) : x)).Sum();
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
