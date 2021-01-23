    public class Data
    {
        public string Property1 { set; get; }
        public string Property2 { set; get; }
    }
            string[] lines = File.ReadAllLines(path);
            IEnumerable<Data> resultArray1 = lines.Select(x =>
            {
                var line = x.Split(',');
                return new Data
                {
                    Property1 = line[0],
                    Property2 = line[1],
                };
            });
            //And loop through the enumeration.
            foreach (var line in resultArray1)
            {
                Console.WriteLine(line.Property1);
                Console.WriteLine(line.Property2);
            }
