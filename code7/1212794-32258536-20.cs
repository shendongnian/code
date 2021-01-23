    namespace WpfApplication1
    {
        // Extract enum description 
        public class EnumDescriptionConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                MemberInfo[] memberInfos = value.GetType().GetMember(value.ToString());
    
                if (memberInfos.Length > 0)
                {
                    object[] attrs = memberInfos[0].GetCustomAttributes(typeof (DescriptionAttribute), false);
                    if (attrs.Length > 0)
                        return ((DescriptionAttribute) attrs[0]).Description;
                }
    
                return value;
    
                // or maybe just
                //throw new InvalidEnumArgumentException(string.Format("no description found for enum {0}", value));
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
