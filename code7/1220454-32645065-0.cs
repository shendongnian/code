    public JsonResult ReadResult()
            {
                Object1 xxx = new Object1();
                Object2 aa = new Object2();
                xxx.x2.Add(aa);
                aa = new Object2();
                aa.y = "200";
                aa.z = "222";
                xxx.x2.Add(aa);
                var json = JsonConvert.SerializeObject(xxx, Formatting.None);
    
    
                return Json(json);
            }
    
    
            public class Object1
            {
                public string x1 = "aaaaa";
                public IList<Object2> x2 = new List<Object2>();
            }
            public class Object2
            {
                public string y = "100";
                public string z = "10";
            }
