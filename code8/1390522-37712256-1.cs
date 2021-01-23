    public static Task<User> LoginByUserNameTaskAsync(this UserService @this, string userName, string password)
    {
      var tcs = new TaskCompletionSource<User>();
      LoginByUserNameCompletedDelegate callback = null;
      callback = (object sender, LoginByUserNameCompletedEventArgs args) =>
      {
        @this.LoginByUserNameCompleted -= callback;
        if (args.Error != null)
          tcs.TrySetException(args.Error);
        else
          tcs.TrySetResult(args.Result);
      };
      @this.LoginByUserNameCompleted += callback;
      @this.LoginByUserNameAsync(userName, password);
      return tcs.Task;
    }
