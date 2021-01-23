    private void ClientCode()
        {
            // Create an array of units 
            IUnit[] units = new IUnit[] {
                new Unit("A"), // A will be called 1st . It needs to be given an initial value to start processing
                new Unit("B"), // B will get A's Output to process. 
                new Unit("C"), // C will get B's Output to process. 
            };
            // pass the array to workflow to process 
            cycle = new WorkFlow(units);
            Console.ReadLine();
        }
