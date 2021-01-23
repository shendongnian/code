        public static async Task AddEvent(Event e)
        {
            using (var client = new HttpClient())
            {
                using (var req = new HttpRequestMessage(HttpMethod.Post, _calendarUrl))
                {
                    var token = await GetToken();
                    req.Headers.Add("Authorization", string.Format("Bearer {0}", token));
                    req.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                    IList<Attendee> attendees = new List<Attendee>();
                    foreach(var a in e.Attendees)
                    {
                        attendees.Add(new Attendee()
                        {
                            EmailAddress = a.EmailAddress,
                            Type = Enum.GetName(typeof(AttendeeType), AttendeeType.Optional)
                        });
                    }
                    var requestContent = JsonConvert.SerializeObject(new
                    {
                        Subject = e.Subject,
                        Body = new
                        {
                            ContentType = "HTML",
                            Content = e.Body.Content
                        },
                        Start = new
                        {
                            DateTime = e.Start,
                            TimeZone = "UTC"
                        },
                        End = new
                        {
                            DateTime = e.End,
                            TimeZone = "UTC"
                        },
                        Attendees = attendees
                    });
                    req.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
                    using (var response = await client.SendAsync(req))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return;
                        }
                        else
                        {
                            throw new HttpRequestException("Event could not be added to calendar");
                        }
                    }
                }
            }
        }
