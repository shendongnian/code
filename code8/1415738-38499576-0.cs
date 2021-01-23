    private static void Funnel()
        {
            var datas = new List<Datas>
                            {
                                new Datas { Name = "Website visits", Value = 10000 },
                                new Datas { Name = "Downloads", Value = 5000 },
                                new Datas { Name = "Requested price list", Value = 2000 },
                                new Datas { Name = "Invoice sent", Value = 1000 },
                                new Datas { Name = "Finalized", Value = 500 }
                            };
            var data = datas.ToDictionary(datas1 => datas1.Name, datas1 => datas1.Value);
            foreach (var item in data)
            {
                Console.WriteLine(string.Format("{0}, {1}",item.Key, item.Value));
            }
            var arry = data.ToArray();
            foreach (var item in arry)
            {
                Console.WriteLine(string.Format("{0}, {1}", item.Key, item.Value));
            }
        }
