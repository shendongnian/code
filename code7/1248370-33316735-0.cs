                var sec = "163516";
                TimeSpan time = TimeSpan.FromSeconds(double.Parse(sec));
                DateTime butikDatetime = DateTime.Today.Add(time);
                string dateTime = butikDatetime.ToString("dd-MM-yy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime date = DateTime.ParseExact(dateTime, "dd-MM-yy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
