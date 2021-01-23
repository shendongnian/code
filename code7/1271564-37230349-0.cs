        static void Main(string[] args)
        {
            UserCredential credential;
            // Copy & Paste from Google Docs
            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            // Create Google Tasks API service.
            var service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            // Define parameters of request.
            TasklistsResource.ListRequest listRequest = service.Tasklists.List();
            // Fetch all task lists
            IList<TaskList> taskList = listRequest.Execute().Items;
            Task task = new Task { Title = "New Task" };
            task.Notes = "Please complete me";
            task.Due = DateTime.Parse("2010-10-15T12:00:00.000Z");
            task.Title = "Test";
            // careful no verification that taskList[0] exists
            var response = service.Tasks.Insert(task, taskLists[0].Id).Execute();
            Console.WriteLine(response.Title);
            Console.ReadKey();
        }
