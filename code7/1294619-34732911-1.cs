	internal class MyApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private IContainer components;
        private AppForm appForm;
        public event EventHandler RestartRequested;
        public MyApplicationContext()
        {
            notifyIcon = new NotifyIcon()
            {
                ContextMenuStrip = new ContextMenuStrip { Text = "Open Form" },
                Text = "Application",
                Visible = true,
                Icon = new Icon("icon.ico")
            };
            appForm = new AppForm();
            notifyIcon.DoubleClick += (o, e) =>
            {
                appForm.Show();
            };
            RestartRequested += (o, e) =>
            {
                appForm?.Close();  //Close() will dispose the form as well.
                notifyIcon?.Dispose();
            };
            BackgroundWork();
        }
        private void BackgroundWork()
        {
            Task.Run<bool>(() => //Here we are telling Task to run a background operation and return a bool
            {
                //this body will run in a separate thread
                Thread.Sleep(5000);  //this represents your background work
                var restart = true;  //whatever result the bg work yields
                return restart;
            }).ContinueWith((task) =>  //task is an instance of Task from above containing the result fromm the background work
            {
                var shouldRestart = task.Result;  // Result is the value you returned in the body Run body above
                if (shouldRestart) RestartRequested?.Invoke(this, EventArgs.Empty);
            },
            TaskScheduler.FromCurrentSynchronizationContext()); //This will return on the UI thread now, no need to worry about thread boundaries
        }
    }
