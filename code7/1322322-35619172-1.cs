      Class AccountInfo
        {
         public int AccountNumber {get;set;}
         public string Name {get;set;}
         public int AtmPin {get;set;}
        public string Check {get;set;}
        public string Saving {get;set;}
        }
        
        Now in your Main program, use that class like this
        List<AccountInfo> accountInfoList= new List<AccountInfo>();
        foreach(string line in File.ReadAllLines("filename"))
        {
           AccountInfo ai =new AccountInfo();
          string[] split = line.Split('*');
                ai.AccountNumber = int.Parse(info [0]) ; 
                ai.Name = info [1] ; 
                ai.AtmPin = int.Parse(info [2]) ; 
                ai.Check = info [3] ; 
                ai.Saving = info [4] ; 
               accountInfoList.Add(ai);
        }
        
        // Some code to accept name and pin from user
        
        // Now compare name and pine like this
        
        var validationSuccessful = accountInfoList.Any(x=>x.AccountNumber==userEnteredAccountNumber &&
                            x.Name==userEnteredName &&
                            x.AtmPin==userEnteredPin);
        
        if(validationSuccessful)
        // Display next screen
        else
        // Display message log in failure
