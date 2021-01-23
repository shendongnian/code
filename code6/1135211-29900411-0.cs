    public enum Option
    {
        Option1,
        Option2
    }
    
    public void Add1(Option option, int variable)
    {
        int ToReturn;        
        ToReturn = variable + 1;
    
        switch(option)
        {
            case Option1:
                Var1 = ToReturn;
                break;
            case Option2:
                Var2 = ToReturn;
                break;
        }
    }
