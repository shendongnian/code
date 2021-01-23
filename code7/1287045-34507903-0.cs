     //mock a collection
            ICollection<string> collection1 = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                collection1.Add("BankStatement");
            }
            for (int i = 0; i < 5; i++)
            {
                collection1.Add("BankStatement2");
            }
            for (int i = 0; i < 4; i++)
            {
                collection1.Add("BankStatement3");
            }
            //merge and get count
            var result = collection1.GroupBy(c => c).Select(c => new { name = c.First(), count = c.Count().ToString() }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.name + ": " + item.count);
            }
