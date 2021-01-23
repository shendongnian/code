     static string GetLogsByTimeStamp(string timeStamp)
        {
            if (!string.IsNullOrEmpty(timeStamp))
            {
                string filePath = @"F:\log.txt"; //your logfile path here
                string format = "hh:mm tt";
                TimeSpan reqTimeStamp = DateTime.ParseExact(timeStamp.Trim(),
                            format, CultureInfo.InvariantCulture).TimeOfDay;
                StringBuilder selectiveLogs = new StringBuilder(string.Empty);
                bool startReading = false;
                foreach (var line in File.ReadLines(filePath))
                {
                    string[] arrItems = line.Split(new[] { ' ' }, 
                                StringSplitOptions.RemoveEmptyEntries);
                    DateTime logDateTime = DateTime.MinValue;
                    bool isDateTimeValid = false;
                    if (arrItems != null && arrItems.Length > 1)
                        DateTime.TryParseExact(string.Format("{0}{1}{2}", 
                            arrItems[0].Trim(), " ", arrItems[1].Trim()), 
                                            format, CultureInfo.InvariantCulture,
                                            DateTimeStyles.None, out logDateTime);
                    TimeSpan logTimeStamp = logDateTime.TimeOfDay;
                    if ((!startReading && logTimeStamp == reqTimeStamp) ||   
                                       (startReading && !isDateTimeValid))
                        startReading = true;
                    if (startReading && logTimeStamp > reqTimeStamp)
                    {
                        startReading = false;
                        break; // no need to continue when you know that u 
                               //reached greater timestamp than required.
                    }
                    if (startReading)
                        selectiveLogs.AppendLine(line);
                }
                return selectiveLogs.ToString();
            }
            else
                return string.Empty;
        }
