    public static void Main ()
    {
        //Check the file path and other validations etc..
    
        using (var fileReader = ...)
        {
            string line;
            while ((line = fileReader.ReadLine()) != null)
            {
                var tokens = line.Split(",");
                if (tokens.Length != ExpectedLength) continue; //this will filter the non-matching cases, including the last two lines
                myOrders.AddRequiredFields(tokens);
            }
        }
    }
