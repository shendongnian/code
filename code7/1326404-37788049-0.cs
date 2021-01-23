    public static Func<TArg, TResult> RetryIfFailed<TArg, TResult>
                                  (this Func<TArg, TResult> func, int maxRetry) {
    return (arg) => {
        int t = 0;
        do {
            try {
                return func(arg);
            }
            catch (Exception) {
                if (++t > maxRetry) {
                    throw;
                }
            }
        } while (true);
     };
    }
      ....
      // get the method we are going to retry with
      Func<DateTime, string> getMyDate = client.GetMyDate;
      // intercept it with RetryIfFailed interceptor, which retries once at most
      getMyDate = getMyDate.RetryIfFailed(1);
      for (var i = 0; i < TimesToInvoke; i++) {
         try {
            // call the intercepted method instead of client.GetMyDate
            getMyDate(DateTime.Today.AddDays(i % 30));
            counter.TotalSuccess++;
         }
       catch (Exception ex) {counter.TotalError++; }
       ....
