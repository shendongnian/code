    public static Task ExecuteTask(Action action, string name)
    {
       var customCulture = CustomCultureInfo.CurrentCulture;
       return Task.Factory.StartNew(() => 
       {
           // use customCulture variable as needed
          // inside the generated task.
       });
    }
