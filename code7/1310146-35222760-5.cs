        private List<Dictionary<string, string>> GetDic(object obj)
        {
            var result= new List<Dictionary<string, string>>();
            foreach (var r in obj.GetType().GetProperties())
            {
                result.Add(new Dictionary<string, string>
                {
                    ["PropertyName"] = r.Name,
                    ["Type"] = r.PropertyType.Name,
                    ["IsPrimitive"] = r.GetType().IsPrimitive.ToString(),
                });
            }
            return result;
        } 
