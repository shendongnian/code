     var people = new List<People>()
                {
                    new People { Name = "Mark", Email = "someone@example.com", Hours = 20 },
                    new People { Name = "Test1", Email = "someone@example.com", Hours = 30 },
                    new People { Name = "Test2", Email = "someone@example.com", Hours = 40 },
                    new People { Name = "Test3", Email = "someone@example.com", Hours = 20 },
                    new People { Name = "Test4", Email = "someone@example.com", Hours = 30 },
                    new People { Name = "Test5", Email = "someone@example.com", Hours = 45 },
                    new People { Name = "Test6", Email = "someone@example.com", Hours = 46 },
                    new People { Name = "Test7", Email = "someone@example.com", Hours = 45 },
                    new People { Name = "Test8", Email = "someone@example.com", Hours = 50 }
                };
    
                var dt = ConvertToDatatable(people);
                var over40 = from s in dt.AsEnumerable()     //We want people over 40 hours
                             where s.Field<int>("Hours") >= 40
                             select s;
                //Stuff this back in a DataTable
                var dtOver40 = ConvertToDatatable(over40.ToList());
                //Under 40
                 var under40 = from s in dt.AsEnumerable()
                          where s.Field<int>("Hours") < 40
                          select s;
                var dtUnder40 = ConvertToDatatable(under40.ToList());
                foreach(var folks in over40)
                {
                    Console.WriteLine(folks[0]);
                    Console.WriteLine(folks[1]);
                    Console.WriteLine(folks[2]);
                }
                
                Console.ReadLine();
