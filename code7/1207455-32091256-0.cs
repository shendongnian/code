    public static string ConvertToMyDateTimeFormat(Nullable<DateTime> value, CultureInfo IFormateProvider)
            {
                if (value.HasValue)
                {
                    if (value.Value.TimeOfDay.Ticks > 0)
                    {
                        return value.Value.ToString(IFormateProvider);
                    }
                    else
                    {
                        return value.Value.ToString(IFormateProvider.DateTimeFormat.ShortDatePattern);
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
