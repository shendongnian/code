    public static Task ExecuteTask(Action action, string name)
    {
       var customCulture = CustomCultureInfo.CurrentCulture;
       return Task.Factory.StartNew((obj) => 
       {
           var culture = (CultureInfo) obj;
           // use customCulture variable as needed
          // inside the generated task.
       }, customCulture);
    }
