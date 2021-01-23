    public async Task FindResultAsync(string[] urlList)
    {
         var downloadTasks = urlList.Select(url => DownloadStringAsync(url)).ToList();
         while (downloadTasks.Count > 0)
         {
              await finishedTask = Task.WhenAny(downloadTasks)
              if (finishedTask.Result == someValue)
              {
                   return finishedTask.Result;
              }
              downloadTasks.Remove(finishedTask);
          }
    }
