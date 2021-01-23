     foreach(string db in dbPurposes)
        {
            if(syPurposes.Contains(db))
            {
                Console.WriteLine("Purpose Found");
            } else
            {
                Console.WriteLine("Purpose Not Found");
            }
        }
