    private async void button_Click(object sender, RoutedEventArgs e)
    {
        string myTaskName = "MyBackgroundClass";
        // check if task is already registered
        foreach (var cur in BackgroundTaskRegistration.AllTasks)
            if (cur.Value.Name == myTaskName)
            {
                await (new MessageDialog("Task already registered")).ShowAsync();
                return;
            }
        // Windows Phone app must call this to use trigger types (see MSDN)
        await BackgroundExecutionManager.RequestAccessAsync();
        // register a new task
        BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder { Name = "MyBackgroundClass", TaskEntryPoint ="MybackgroundStuff.MyBackgroundClass" };
        taskBuilder.SetTrigger(new TimeTrigger(15, true));
        BackgroundTaskRegistration myFirstTask = taskBuilder.Register();
