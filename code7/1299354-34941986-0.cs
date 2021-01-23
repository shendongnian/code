    OutlookServicesClient client = new OutlookServicesClient(new Uri("https://outlook.office.com/api/v2.0"),
                    async () =>
                    {
                        // Since we have it locally from the Session, just return it here.
                        return token;
                    });
              
                Location location = new Location
                {
                    DisplayName = "Water cooler"
                };
                // Create a description for the event    
                ItemBody body = new ItemBody
                {
                    Content = "Status updates, blocking issues, and next steps",
                    ContentType = BodyType.Text
                };
                // Create the event object
                DateTimeTimeZone start=new DateTimeTimeZone() ;
                string dateTimeFormat = "yyyy-MM-ddThh:mm:ss";
                string timeZone = "Pacific Standard Time";//"Eastern Standard Time";
                start.DateTime = new DateTime(2016, 1, 22, 14, 30, 0).ToString(dateTimeFormat);
                start.TimeZone = timeZone;
                DateTimeTimeZone end = new DateTimeTimeZone();
                end.DateTime = new DateTime(2016, 1, 22, 15, 30, 0).ToString(dateTimeFormat);
                end.TimeZone = timeZone;
                Event newEvent = new Event
                {
                    Subject = "Sync up",
                    Location = location,
                    Start = start,
                    End = end,
                    Body = body
                };
                newEvent.Recurrence = new PatternedRecurrence();
                newEvent.Recurrence.Range = new RecurrenceRange();
                string dateFormat = "yyyy-MM-dd";
                newEvent.Recurrence.Range.EndDate = DateTime.Now.AddYears(1).ToString(dateFormat);
                newEvent.Recurrence.Range.StartDate = DateTime.Now.ToString(dateFormat);
                newEvent.Recurrence.Range.NumberOfOccurrences = 11;
                newEvent.Recurrence.Pattern = new RecurrencePattern();
                newEvent.Recurrence.Pattern.Type = RecurrencePatternType.Weekly;
                newEvent.Recurrence.Pattern.Interval = 1;
                newEvent.Recurrence.Pattern.DaysOfWeek= new List<Microsoft.Office365.OutlookServices.DayOfWeek>() { Microsoft.Office365.OutlookServices.DayOfWeek.Friday };
                // Add the event to the default calendar
                await client.Me.Events.AddEventAsync(newEvent);
