    Dictionary<string, string> myDict = new Dictionary<string, string>(){
                                                    { "abc","Message 1" },
                                                    {"def","Message 1" },
                                                    {"ghi","Message 2"} ,
                                                    {"jkl","Message 1"} ,
                                                    {"mno","Message 2"} ,
                                                    {"pqr","Message 3"}
                                                    };
                var temp = myDict.GroupBy(c => c.Value);
                foreach (var i in temp)
                {
                    Console.WriteLine(i.Key);
                    foreach (var k in i)
                    {
                        Console.WriteLine("{0}", k.Key);
                    }
                    Console.WriteLine("=============");
    
                }
