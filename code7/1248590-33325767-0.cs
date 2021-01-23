          Dictionary<string,object> ParameterTypes  = new Dictionary<string,object>();
        //Populate the parameterTypes here
         foreach (var x in ParameterTypes)
        {
            Console.WriteLine(x.Key + " -- ");
            foreach (var in x.Value)
            {
                Console.WriteLine(y.Key + ": " + y.Value);
            }
            Console.WriteLine("\n");
        }
