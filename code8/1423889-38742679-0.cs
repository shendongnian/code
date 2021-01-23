             string value = "2009.99";
             if (IsDecimal(value, 4, 4))
             { 
                Console.WriteLine("Valid");
             }
        private static bool IsDecimal(string value, int before, int after)
        {
            var r = new Regex(@"^\d{1," + before + @"}(\.\d{0," + after + @"})$");
            return r.IsMatch(value);
        }
