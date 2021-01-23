    protected void Page_Load(object sender, EventArgs e)
        {
            var task = 
                Task.Factory.StartNew(
                    () => 
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        litResult.Text = "Hello World!";
                    });
            RegisterAsyncTask(task.ToPageAsyncTask()); // RegisterAsyncTask is a method from Page.
        }
