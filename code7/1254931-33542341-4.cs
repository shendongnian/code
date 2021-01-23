    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is MovieType)
                {
                    FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
                    if (fieldInfo != null)
                    {
                        object[] attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                        if (attributes.Length > 0)
                        {
                            return ((DescriptionAttribute)attributes[0]).Description;
                        }
                    }
                }
                return value;
            }
