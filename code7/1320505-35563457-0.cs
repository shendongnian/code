    public void MyFunction(int method, object acceptEverything)
    {
        switch(method)
        {
            case 1: ContinueExample1(acceptEverything as string);
                    break;
            case 2: ContineExample2(acceptEverything as int);
                    break;
            // etc.
        }
    }
