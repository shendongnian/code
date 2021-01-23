    Delegate[] delegates = d1.GetInvocationList();
                foreach (Action d in delegates)
                {
                    try
                    {
                        d();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Exception Caught : "+e.Message);
    
                    }
                 }
