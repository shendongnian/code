            var list = new List<object> {new { A = 1, B = 2, C = 3}, new {A = 1, B = 1, D = 1}};
            var result = new ExpandoObject(); 
       
            var list1 = list.Aggregate<object, ExpandoObject>(result, (res, a) =>
            {
                foreach (var prop in a.GetType().GetProperties())
                {
                    object val = prop.GetValue(a);
                    var x = res as IDictionary<string, Object>;
                    object o;
                    if (!x.TryGetValue(prop.Name, out o))
                    {
                        o = new List<object>();
                        x.Add(prop.Name, o);
                    }
                    ((List<object>)o).Add(val);
                }
                return res;
            });
          
                var inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            var outputJson = Newtonsoft.Json.JsonConvert.SerializeObject(list1);
