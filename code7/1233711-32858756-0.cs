    List<Dictionary<string, string>> data1 = new List<Dictionary<string, string>>();
    
    
                Dictionary<string, string> dic1 = new Dictionary<string, string>();
                dic1.Add("101", "one");
                dic1.Add("102", "two");
                data1.Add(dic1);
    
                dic1 = new Dictionary<string, string>();
                dic1.Add("201", "2one");
                dic1.Add("202", "2two");
                data1.Add(dic1);
    
                dic1 = new Dictionary<string, string>();
                dic1.Add("301", "3one");
                dic1.Add("302", "3two");
                data1.Add(dic1);
    
                //try your values here
                var id = "201";
                var s=data1.Where(c => c.Keys.Contains(id)).Select(c => c.Keys.Where(p => p == id).Select(p => c[p]).FirstOrDefault()).FirstOrDefault();
                Console.WriteLine(s);
