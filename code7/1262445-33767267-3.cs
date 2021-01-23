    namespace UpdateUploader.Services
    {
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Threading;
        using System.Threading.Tasks;
        using Google.Apis.Auth.OAuth2;
        using Google.Apis.Drive.v2;
        using Google.Apis.Drive.v2.Data;
        using Google.Apis.Services;
        using Google.Apis.Util.Store;
        using Google.Apis.Upload;
    
        class DriveHelper
        {
            private static bool _unique;
    
            public static DriveService createDriveService(string passFilePath, bool createUniqueID)
            {
                _unique = createUniqueID;
    
                if (!System.IO.File.Exists(passFilePath))
                {
                    Console.Error.WriteLine("keyfile not found...");
                    return null;
                }
    
                string[] scopes = new string[] { DriveService.Scope.Drive }; // Full accces
    
                // loading the key file
                UserCredential credential;
    
                using (var stream = new System.IO.FileStream("client_secret.json", System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = System.IO.Path.Combine(credPath, ".credentials/update-uploader");
    
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
    
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Update Uploader",
                });
                return service;
            }
    
            // search = null ; get all files/folders
            public static async Task<List<File>> getFiles(DriveService service, string search)
            {
                System.Collections.Generic.List<File> Files = new System.Collections.Generic.List<File>();
                try
                {
                    // list all files with max 1000 results
    
                    FilesResource.ListRequest list = service.Files.List();
                    list.MaxResults = 1000;
                    if (search != null)
                    {
                        list.Q = search;
                    }
                    FileList filesFeed = await list.ExecuteAsync();
    
                    while (filesFeed.Items != null)
                    {
                        foreach (File item in filesFeed.Items)
                        {
                            Files.Add(item);
                        }
    
                        // if it is the last page break
                        if (filesFeed.NextPageToken == null)
                        {
                            break;
                        }
    
                        list.PageToken = filesFeed.NextPageToken;
    
                        filesFeed = list.Execute();
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                return Files;
            }
