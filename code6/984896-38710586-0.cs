      public static async Task<string> AuthenticateAsync(string userName, string password)
        {
            var dataAccessServiceClient = new DataAccessServiceClient("DataAccessService");
    
            var taskCompletionSource = new TaskCompletionSource<string>();
    
            EventHandler<AuthenticateCompletedEventArgs> completedHandler = null;
            completedHandler = (s, args) =>
            {
                try
                {
                    taskCompletionSource.SetResult(args.Result);
                }
                catch (Exception e)
                {
                    taskCompletionSource.SetException(e);
                }
            };
    
            dataAccessServiceClient.AuthenticateCompleted += completedHandler;
            dataAccessServiceClient.AuthenticateAsync(userName, password);
    
            return await taskCompletionSource.Task;
        }
