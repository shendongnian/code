    var username = this.Username;
    var password = pwdBox.Password;
    Task.Factory.StartNew(() => //This will run using a Thread-Pool thread which will not cause the UI to be unresponsive.
    {
        //Do expensive operations here, like data access
        //You cannot access the UI here
        bool valid = DoSomeExpensiveCallsToDetermineIfPasswordIsValid(username, password);
        return valid;
    })
    .ContinueWith( t => //This will run on the UI thread
    {
        bool valid = t.Result;
                
        if (valid)
        {
            //Do some UI to indicate that the password is valid
        }
        else
        {
            //Do some UI to indicate that the password is not valid
        }
    }, CancellationToken.None,
    TaskContinuationOptions.OnlyOnRanToCompletion, //Only run this if the first action did not throw an exception
    TaskScheduler.FromCurrentSynchronizationContext()); //Use the UI thread to run this action
