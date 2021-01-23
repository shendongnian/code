    void Method2()
    {
        if(error)
        {
            throw(new Method2Exception("error"));
        }
    
        //Do something and call method3
        try
        {
            Method3();
        }
        catch(Method3Exception exc)
        {
            throw new Method2Exception("error", exc); // exc is passed as inner exception
        }
    }
