     DateTimeFormatter[] timeFormatters = new[]
            {
                // Example formatters for times.
                new DateTimeFormatter(
                    HourFormat.Default, 
                    MinuteFormat.Default, 
                    SecondFormat.Default),
                new DateTimeFormatter(
                    HourFormat.Default, 
                    MinuteFormat.Default, 
                    SecondFormat.None),
                new DateTimeFormatter(
                    HourFormat.Default, 
                    MinuteFormat.None, 
                    SecondFormat.None),
             };
