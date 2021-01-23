            object[] internationalRates = new object[] 
            { 
                new { name = "London", value = 1 }, 
                new { name = "New York", value = 2 } , 
            };
            var dict = internationalRates.ToDictionary<int, string>("value", "name");
            foreach (KeyValuePair<int, string> item in dict)
                Console.WriteLine(item.Key + "  " + item.Value);
            Console.ReadLine();
