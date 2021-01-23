    void Method1()
    {
        try
        {
            Method2();
        }
        catch(Method2Exception ex)
        {
            if(ex.InnerException != null)
            {
                var message = ex.InnerException.Message;
                // Do what you need with the message
            }
        }
    }
