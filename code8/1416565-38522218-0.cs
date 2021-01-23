    private static async void TestFtpAsync(string userName, string password, string ftpBaseUri,
          IEnumerable<string> fileNames)
        {
          var tasks = new List<Task<byte[]>>();
          foreach (var fileInfo in fileNames.Select(fileName => new FileInfo(fileName)))
          {
            using (var webClient = new WebClient())
            {
              webClient.Credentials = new NetworkCredential(userName, password);
              tasks.Add(webClient.UploadFileTaskAsync(ftpBaseUri + fileInfo.Name, fileInfo.FullName));
            }
          }
          Console.WriteLine("Uploading...");
          foreach (var task in tasks)
          {
            try
            {
              await task;
              Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.ToString());
            }
          }
        }
