    public void MyFunction<T>(int method, T acceptEverything)
    {
        switch(method)
        {
            case 1: ContinueExample1(acceptEverything as string); //String parameter
                    break;
    
            case 2: ContineExample2(Convert.ToInt32(acceptEverything)); //int parameter 
                    break;
            // etc.
        }
    }
