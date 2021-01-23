        catch ( Exception e )
        {
            Type etype = e.GetType();
            if (etype == typeof(ArgumentException))
            {
                Console.WriteLine("Invalid Arguments: {0}", e.Message);
            }
            else if (etype == typeof(ArgumentOutOfRangeException))
            {
                Console.WriteLine("Arguments Out of Range: {0}", e.Message);
            }
            // ...
        }
