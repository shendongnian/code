    // populated with types and data that mean something
    // to you. 
    private IDictionary<int, string> _lookupDictionary; 
    public string GetValue(int variable) {
        return _lookupDictionary[variable];
        
        // instead of 
        // switch (variable) { 
        //     case 1: 
        //         return <somevalue>; 
        //     case 2:
        //         return <someothervalue>; 
        //     ...
        //     case n-1: 
        //         return <somethingelse>; 
        //     case n: 
        //         return <finalsomething>; 
    }
