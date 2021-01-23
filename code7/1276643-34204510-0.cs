    protected void Page_Load(object sender, EventArgs e)
    {
        PageAsyncTask t = new PageAsyncTask(SendTweetWithSinglePicture("test", "path"));
        // Register the asynchronous task.
        Page.RegisterAsyncTask(t);
        // Execute the register asynchronous task.
        Page.ExecuteRegisteredAsyncTasks();
    }
