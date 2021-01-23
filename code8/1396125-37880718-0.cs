    public class DisplayMemberPathConverter : IValueConverter
        {
            /// <summary>
            /// Convert 
            /// </summary>
            /// <param name="value">YourItemSourceItem</param>
            /// <param name="targetType"></param>
            /// <param name="parameter">DisplayMemberPath</param>
            /// <param name="culture"></param>
            /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value.GetType().GetProperty(parameter.ToString()).GetValue(value, null);
            }
        }
