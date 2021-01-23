    var c = new MyClass()
                {
                    rows = new List<string>()
                    {
                        "string1",
                        "string2",
                        "string3"
                    }
    
                };
                Console.WriteLine(JsonConvert.SerializeObject(c));
                Console.Read();
