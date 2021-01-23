        static string[] Scopes = { CalendarService.Scope.CalendarReadonly, DirectoryService.Scope.AdminDirectoryUserReadonly };
        private static void GoogleThis()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            // Create Google Calendar API service.
            var eventService = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            // Define parameters of request.
            EventsResource.ListRequest eventRequest = eventService.Events.List("primary");
            eventRequest.TimeMin = DateTime.Now;
            eventRequest.ShowDeleted = false;
            eventRequest.SingleEvents = true;
            //request.MaxResults = 10;
            eventRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            // List events.
            Events events = eventRequest.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            // Create Directory API service.
            var dirService = new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            // Define parameters of request.
            UsersResource.ListRequest dirRequest = dirService.Users.List();
            dirRequest.Customer = "my_customer";
            dirRequest.MaxResults = 10;
            dirRequest.OrderBy = UsersResource.ListRequest.OrderByEnum.Email;
            // List users.
            IList<User> users = null;
            try
            {
                users = dirRequest.Execute().UsersValue;
                Console.WriteLine("Users:");
                if (users != null && users.Count > 0)
                {
                    foreach (var userItem in users)
                    {
                        Console.WriteLine("{0} ({1})", userItem.PrimaryEmail,
                            userItem.Name.FullName);
                    }
                }
                else
                {
                    Console.WriteLine("No users found.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
