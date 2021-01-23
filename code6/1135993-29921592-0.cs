    public void methodMain()
    {
        Action[] actions = new Action[]
        {
           method1,
           method2
        };
    
        foreach(var method in actions)
        {
            try
            {
                method();
            }
            catch (WebException e)
            {
                //do something
            }
        }
    }
