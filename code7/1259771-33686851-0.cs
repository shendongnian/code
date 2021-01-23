    public BackUpViewModel()
    {                       
        BackUpContext servObj = new BackUpContext();
       _ServerNameList = servObj.GetServers();     
       
       // Select the first.
       fetchServer(_ServerNameList.FirstOrDefault());
    }
