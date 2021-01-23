        public IMyType GetAppropriateType(string input)
        { 
        if (inputData.item.Split('(')[1].Split(')')[0].Contains(':'))
                 {
                    return new Type2 {Input = input};
                 }
        //etc
        }
        
        public string ProcessGET(List<string> inputData)
        {
              foreach(var itm in inputData)
              { 
                 IMyType type = GetAppropriateType(itm);
                 type.Result();
              
              }   
        }
