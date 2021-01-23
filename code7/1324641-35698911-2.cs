    class Foo
    {
        DoSomething(int param)
        {
            try 
            {
                 if (/*Something Bad*/)
                 {  
                     //violates business logic etc... 
                     throw new FooException("Reason...");
                 }
                 //... 
                 //something that might throw an exception
            }
            catch (FooException ex)
            {
                 throw;
            }
            catch (Exception ex)
            {
                 throw new FooException("Inner Exception", ex);
            }
        }
    }
