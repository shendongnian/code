    public int Main()
    {
        try
        {
            try
            {
                A()
            }
            catch(InvalidOperationException e)
            {
                //handle
            }
    
            try
            {
                B()
            }
            catch(ArgumentOutOfRangeException e)
            {
                //handle
            }
            catch(ArgumentNullException e)
            {
                //handle
            }
    
            try
            {
                C()
            }
            catch(AccessViolationException e)
            {
                //handle
            }
        }
        catch (Exception e)
        {
            //handle all other exceptions
        }
    }
