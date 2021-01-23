    static void Main(string[] args)
            {
                //one-many
                using (var context = new Context())
                {
                    var values = new List<DynamicDataValue>();
                    for (int i = 0; i < 11; i++)
                    {
                        values.Add(new DynamicDataValue { Value = string.Format("Value{0}", i) });
                    }
    
                    context.DynamicDatas.Add(new DynamicData { Values = values });
    
                    context.SaveChanges();
    
                    var query =
                        context.DynamicDatas.Select(
                            data => new { data.Id, values = data.Values.Select(value => value.Value) }).ToList();
    
                    foreach (var item in query)
                    {
                        var strings = item.values.Aggregate((s, s1) => string.Format("{0},{1}", s, s1));
                        Console.WriteLine("{0} - {1}", item.Id, strings);
                    }
                }
    
                Console.ReadLine();
    
                //comma seperated
                using (var context = new Context())
                {
                    var values = new List<string> { "value1", "value2", "value3" };
                    context.DynamicData2s.Add(new DynamicData2 { Values = values.Aggregate((s, s1) => string.Format("{0},{1}", s, s1)) });
                    context.SaveChanges();
    
                    var data = context.DynamicData2s.ToList();
                    foreach (var dynamicData2 in data)
                    {
                        Console.WriteLine("{0}-{1}", dynamicData2.Id, dynamicData2.Values);
                    }
                }
    
            }
