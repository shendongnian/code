    typeof(SomeClass).Assembly.GetTypes().Select(x => new
                                {
                                     x.Name, 
                                     PropertyCount = x.GetType().GetProperties().Count()
                                });
