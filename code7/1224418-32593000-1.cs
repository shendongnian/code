    var outputDate = myEvents.OrderByDescending(x=>
                              {
                               DateTime parsedDate;
                               return DateTime.TryParseExact(x.StartDate, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate) ? parsedDate : DateTime.MinValue;
                              });
