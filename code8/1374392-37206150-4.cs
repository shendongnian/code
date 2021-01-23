    public string Property1 {get;set;} 
    
    public void ConstructorOrMethod()
    {
        Property1 = System.Configuration.ConfigurationSettings.AppSettings["key1"]; 
    }
