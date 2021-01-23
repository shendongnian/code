                public static Nullable<DateTime> AsNullableDateTime(this object item, Nullable<DateTime> defaultDateTime = null)
                {
                    if (item == null || string.IsNullOrEmpty(item.ToString()))
                        return defaultDateTime;
        
                    DateTime result;
                    if (!DateTime.TryParse(item.ToString(), out result))
                        return defaultDateTime;
        
                    return result;
                }
