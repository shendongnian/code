    List<Task> tasks = new List<Task>();
    for (int i = 0; i <= 200; i++)
    {
        tasks.Add(new Task(() =>
            {
                var lines = File.ReadAllLines(@"D:\file_" + i.ToString().PadLeft(5, '0') + ".txt");
                foreach (var line in lines)
                {
                    WebRequest request = WebRequest.Create("ftp://myftp/dir/" + line);
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    request.Credentials = new NetworkCredential("user", "pass");
                    request.GetResponse();
                }
            }
        ));
    }
    Task.WaitAll(tasks.ToArray());
