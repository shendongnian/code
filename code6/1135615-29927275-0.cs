        public void ReadNumbers(string fileName)
        {
            File.ReadAllLines(fileName)
                .Select(l => double.Parse(l.Trim()))
                .OrderBy(n => n)
                .ToList()
                .ForEach(n => Console.Write("{0}    ", n));
        }
