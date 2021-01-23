                    Producer prod1 = new Producer("prod1", 5);
                    Producer prod2 = new Producer("prod2", 6);
                    Producer prod3 = new Producer("prod3", 7);
    
                    Cheese gouda = new Cheese("Gouda", 5, "Mild");
                    gouda.Producers.Add(prod1);
                    gouda.Producers.Add(prod2);
                    gouda.Producers.Add(prod3);
    
                    var propertiesToBeAdded = File.ReadAllText(@"C:\json path");
                    
                    var settings = new JsonMergeSettings
                    {
                        MergeArrayHandling = MergeArrayHandling.Merge
                    };
    
                    var o1 = JObject.Parse(JsonConvert.SerializeObject(gouda));
    
                    o1.Merge(JObject.Parse(propertiesToBeAdded), settings);
    
                    var o = o1.ToString();
