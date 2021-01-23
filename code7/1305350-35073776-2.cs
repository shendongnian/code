    class MyJson
    {
        public static string SerializeObject<T>(T obj, bool ignoreBase)
        {
            if (!ignoreBase)
            {
                return JsonConvert.SerializeObject(obj);
            }
            var myType = typeof(T);
            var props = myType.GetProperties().Where(p => p.DeclaringType == myType).ToList();
            var x = new ExpandoObject() as IDictionary<string, Object>;
            props.ForEach(p => x.Add(p.Name, p.GetValue(obj, null)));
            return JsonConvert.SerializeObject(x);
        }
    }
