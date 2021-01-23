    // UNREGISTER THE EXISTING TASK IF IT EXISTS
    var myTask = BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault(iTask => iTask.Name == "DoSomethingBackground");
    if (myTask != null) myTask.Unregister(true);
    // REGISTER NEW TASK TO EXECUTE EVERY 30 MINUTES
    BackgroundTaskBuilder myTaskBuilder = new BackgroundTaskBuilder() { Name = "DoSomethingBackground", TaskEntryPoint = "WindowsRuntimeComponent1.MyBackgroundClass" };
    myTaskBuilder.SetTrigger(new TimeTrigger(30, false));
    myTaskBuilder.Register();
    // CREATE/RESET THESE VARIABLES
    ApplicationData.Current.LocalSettings.Values["gap time minutes"] = 60;
    ApplicationData.Current.LocalSettings.Values["time stamp"] = DateTime.Now.ToString(CultureInfo.InvariantCulture);
