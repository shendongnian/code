    switch (arg)
        {
            case 0:
                {
                    Exception ex = new Exception("Line number = 37");
                    Console.WriteLine("case 0");
                    throw ex;
                }
            case 1:
                {
                    Exception ex = new Exception("Line number = 43");
                    Console.WriteLine("case 1");
                    throw ex;
                }
            default:
                {
                    Exception ex = new Exception("Line number = 49");
                    Console.WriteLine("case default");
                    throw ex;                    
                }
        }
