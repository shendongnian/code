              Dictionary<string, string> delta = new Dictionary<string, string>();
                delta.Add("A", "One");
                delta.Add("B", "Two");
                delta.Add("C", "Three");
    
                string key = "A";
                string value = delta[key];
                Console.WriteLine(  value);
