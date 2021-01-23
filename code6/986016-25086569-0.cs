    using (var worker = new BackgroundWorker())
    {
        worker.DoWork += (theSender, theArgs) =>
        {
            theArgs.Result = isAuthenticated(userName, password);
        };
        worker.RunWorkerCompleted += (theSender, theArgs) =>
        {
            bool isValid = (bool)theArgs.Result;
            if(!isValid)
            {
                MessageBox.Show("Not Authenticated!!");
            }
        };
        worker.RunWorkerAsync();
    }
