      public void Run()
      {
          List<string> urls = File.ReadAllLines(@"c:/temp/Input/input.txt").ToList();
    
          Barrier barrier = new Barrier(url.Count, ()=> {Console.WriteLine("Start now");} );
          Task[] tasks = new Task[urls.Count()];
          Parallel.For(0, urls.Count, (int index)=>
          {
               string path = string.Format("{0}image-{1}.jpg", @"c:/temp/Output/", index+1);
              tasks[index] = DownloadAsync(Uri(urls[index]), path, barrier);        
          })
          Task.WaitAll(tasks); // wait for completion
          Console.WriteLine("Done");
        }
        async Task DownloadAsync(Uri url, string path, Barrier barrier)
        {
               using (WebClient wc = new WebClient())
               {
                    barrier.SignalAndWait();
                    await wc.DownloadFileAsync(url, path);
                    Output(path);
               }
        }
