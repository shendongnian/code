        static void Main(string[] args)
        {
            List<string> str = new List<string>() { "A01943486", "102-2009-1008", "A-146", "0622008081A", 
                                                    "Ematol OPBG", "Yavuz1098083", "Yeter1391671"};
            List<int> extractedNumbers = new List<int>();
            Regex reg = new Regex("[0-9]+");
            foreach (var item in str)
            {
                Match m = reg.Match(item);
                if (m.Success)
                {
                    int num = Convert.ToInt32(m.Value.TrimStart('0'));
                    extractedNumbers.Add(num);
                }
            }
        }
