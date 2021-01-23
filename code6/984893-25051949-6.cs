    public static class WebClientExtensions 
    {
        public static Task<Stream> OpenReadTaskAsync(this WebClient client, Uri uri)
        {
           var tcs = new TaskCompletionSource<Stream>();
           OpenReadCompletedEventHandler openReadEventHandler = null;
           openReadEventHandler = (sender, args) => 
           {
              try 
              {
                 tcs.SetResult(args.Result);
              } 
              catch (Exception e)
              {
                 tcs.SetException(e);
              }
           };
           client.OpenReadCompleted += openReadEventHandler;
           client.OpenReadAsync(uri);
    
           return tcs.Task;
        }
    }
