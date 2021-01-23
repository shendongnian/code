               DateTimeFormatInfo info = new CultureInfo("zh-HK", false).DateTimeFormat;
                string formattedDate = "";
                var dateTime = DateTime.MinValue;
                if (DateTime.TryParse("06/01/2015", out dateTime))
                {
                    formattedDate = dateTime.ToString(info.LongDatePattern);
                }​
