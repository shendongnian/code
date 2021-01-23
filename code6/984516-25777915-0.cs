    public static void CompleteOnBackgroundThread(this Action action)
    {
        ManualResetEvent mre = new ManualResetEvent(false);
        Exception exception = null;
        WindowsIdentity appId = System.Security.Principal.WindowsIdentity.GetCurrent();
        Action surroundingAction = () =>
        {
            try
            {
                using (WindowsImpersonationContext wi = appId.Impersonate())
                {
                    action();
                }
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count == 1)
                {
                    // Get the wrapped exception
                    exception = ex.InnerExceptions.First();
                }
                else
                {
                    exception = ex;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
               
            finally
            {
                mre.Set();
            }
        };
        surroundingAction.BeginInvoke(null, null);
        mre.WaitOne(TimeSpan.FromSeconds(1.0));
        if (exception != null)
        {
            throw exception;
        }
    }
