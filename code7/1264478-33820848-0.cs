            Dictionary<string, int> database = new Dictionary<string, int>();
            database.Add("Week1 Monday", 10);
            database.Add("Week1 Wednesday", 20);
            //etc...
            string userinput = "Week1 Monday";
            int numberOfBears;
            if (database.ContainsKey(userinput))
                numberOfBears = database[userinput];
            //numberOfBears = 10
