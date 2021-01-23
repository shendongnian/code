        {
            string pattern = @"\-*\d+";
            string value="Mitchell, -10";
            Match oMatch=Regex.Match(value,pattern);
            if (int.Parse(oMatch.Value) < 0)
            {
                Console.WriteLine(oMatch.Value);
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine(oMatch.Value);
                Console.ReadKey(true);
            }
        }
