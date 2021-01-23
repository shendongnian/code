        var tokens3 = "1,2,3****5,8,9,1,2,3****1,2,3,4,5,6,7,8,9";
        string[] tokens4 = tokens3.Split(new string[] { "****" }, StringSplitOptions.None);
        foreach(string token in tokens4)
        {
            var rows = token.Split(new string[] { "," }, StringSplitOptions.None);
            foreach(var row in rows)
            {
                // Here you have an access to the row value
                Console.WriteLine(row);
            }
            Console.WriteLine();
        }
