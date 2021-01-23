    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v3;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    namespace DriveQuickstart
    {
        class Program
        {
            // If modifying these scopes, delete your previously saved credentials
            // at ~/.credentials/drive-dotnet-quickstart.json
            static string[] Scopes = { DriveService.Scope.DriveReadonly };
            static string ApplicationName = "Drive API .NET Quickstart";
            static DriveService service;
            static Dictionary<string, Google.Apis.Drive.v3.Data.File> files = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();
            static void Main(string[] args)
            {
                UserCredential credential;
                using (var stream =
                    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
                // Create Drive API service.
                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                // Define parameters of request.
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.PageSize = 10;
                listRequest.Fields = "nextPageToken, files(id, name, parents)";
                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                    .Files;
                Console.WriteLine("Files:");
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var absPath = AbsPath(file);
                        Console.WriteLine("{0} ({1})", absPath, file.Id);
                    }
                }
                else
                {
                    Console.WriteLine("No files found.");
                }
                Console.Read();
            }
            private static object AbsPath(Google.Apis.Drive.v3.Data.File file)
            {
                var name = file.Name;
                if (file.Parents.Count() == 0)
                {
                    return name;
                }
                var path = new List<string>();
                while (true)
                {
                    var parent = GetParent(file.Parents[0]);
                    // Stop when we find the root dir
                    if (parent.Parents == null || parent.Parents.Count() == 0)
                    {
                        break;
                    }
                    path.Insert(0, parent.Name);
                    file = parent;
                }
                path.Add(name);
                return path.Aggregate((current, next) => Path.Combine(current, next));
            }
            private static Google.Apis.Drive.v3.Data.File GetParent(string id)
            {
                // Check cache
                if (files.ContainsKey(id))
                {
                    return files[id];
                }
                // Fetch file from drive
                var request = service.Files.Get(id);
                request.Fields = "name,parents";
                var parent = request.Execute();
                // Save in cache
                files[id] = parent;
                return parent;
            }
        }
    }
