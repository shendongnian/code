     static void Main(string[] args)
            {
                Dictionary<string, List<string>> dictTestdata = new Dictionary<string, List<string>>
            {
                { "k1", new List<string> { "1", "Programmers" }},
                { "k2", new List<string> { "3", "Testers" }},
                { "k3", new List<string> { "", "Designers" }}, 
            };
    
                var data =   dictTestdata.Values.Where(m => string.IsNullOrEmpty(m.ElementAtOrDefault(0)));
                foreach (List<string> item in data)
                {
                    Console.WriteLine(item.ElementAtOrDefault(1));
                }
    
                dictTestdata = new Dictionary<string, List<string>>
            {
                { "k1", new List<string> { "", "Programmers" }},
                { "k2", new List<string> { "", "Testers" }},
                { "k3", new List<string> { "", "Designers" }}, 
            };
                 data = dictTestdata.Values.Where(m => string.IsNullOrEmpty(m.ElementAtOrDefault(0)));
                foreach (List<string> item in data)
                {
                    Console.WriteLine(item.ElementAtOrDefault(1));
                }
                Console.Read();
            }
