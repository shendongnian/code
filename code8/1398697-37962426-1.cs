        static class JSONhelper
    {
        public static IList<T> DeserializeToList<T>(string jsonString)
        {
            var array = Newtonsoft.Json.Linq.JArray.Parse(jsonString);
            
            IList<T> objectsList = new List<T>();
            foreach (var item in array)
            {
                try
                {
                    objectsList.Add(item.ToObject<T>());       
                }
                catch { }    
            }
            return objectsList;
        }
    }
