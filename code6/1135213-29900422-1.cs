    enum Options {
        Option1 = 1,
        Option2 = 2
    }
    class Special
    {
    int Var1;
    int Var2;
    
    public void Add1(Options option, int variable)
    {
        int ToReturn;        
        ToReturn = variable + 1;
    
        switch(option)
        {
            case Options.Option1:
                Var1 = ToReturn;
                break;
            case Options.Option2:
                Var2 = ToReturn;
                break;
        }
    }
    }
