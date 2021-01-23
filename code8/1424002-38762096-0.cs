    // the loop
    foreach (string name in fileArray)
    {    
        EstablishConnection(name); // you might need a full path!
        //do search...
    }
    
    // a little change in the EstablishConnection method
    private void EstablishConnection(String dbPath)
    {
        string connParamTemplate = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}";
        String conn = String.Format(connParamTemplate, name);
        
        //connect... notice the change in OpenConnection!
    
    // a little change in the OpenConnection method
    private void OpenConnection(String connParam)
