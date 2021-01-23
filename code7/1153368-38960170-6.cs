    public void ConfigureServices(IServiceCollection services)
    {
       // Tells the pipeline we want to use IOption Assessor Services
       services.AddOptions();
       // Injects the object VariablesNeeded in to the pipeline with our desired variables
       services.Configure<VariablesNeeded>(x =>
       {
           x.Foo1 = Configuration["KeyInAppSettings"]
           x.Foo2 = Convert.ToInt32(Configuration["KeyParentName:KeyInAppSettings"])
       });
       //You may want another set of options for another controller, or perhaps to pass both to our "MyController" if so, you just add it to the pipeline    
       services.Configure<OtherVariablesNeeded>(x =>
       {
           x.Foo1 = "Other Test String",
           x.Foo2 = 2
       });
       //The rest of your configure services...
    }
