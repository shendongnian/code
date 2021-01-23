    public void MyFunction<T>(int method, T acceptEverything)
    {
        switch(method)
        {
            case 1: ContinueExample1(acceptEverything); //String parameter
                    break;
    
            case 2: ContineExample2(acceptEverything); //int parameter 
                    break;
            // etc.
        }
    }
