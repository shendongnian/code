    protected string FirstArg { get; set; }
    protected string SecondArg { get; set; }
    
    // read from configuration file
    protected string ConfigArgument { get { return ConfigurationManager.AppSettings["key"]; } }
    
    protected override void OnStart(string[] args)
    {
        base.OnStart(args);
    
        // read from console
        FirstArg= args[0];
        SecondArg = args[1];
        //read more arguments
    }
