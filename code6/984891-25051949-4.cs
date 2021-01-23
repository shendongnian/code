    public static class WebClientExtensions 
    {
        public static Task<Stream> OpenReadTaskAsync(this WebClient client, Uri uri)
        {
           var tcs = new TaskCompletionSource<Stream>();
           client.OpenReadCompleted += (sender, args) => 
           {
              try 
              {
                 taskComplete.SetResult(args.Result);
              } 
              catch (Exception e)
              {
                 taskComplete.SetException(e);
              }
           };
    
           client.OpenReadAsync(uri);
    
           return tcs.Task;
        }
    }
