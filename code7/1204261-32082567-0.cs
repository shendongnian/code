    public ProcessDataService(IExceptionRepository evpRepo, IOutputService outputService)
    {           
        _exceptionRepository = evpRepo;  
        _outputService = _outputService;          
    }
    
    public void ProcessLastException()
    {
        _outputService.Command() //or whatever suitable name you for your method
    }
