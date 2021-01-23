    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    static class Filter
    {
        public static object FilterObject(Person input, string[] whitelist)
        {
            var o = new ExpandoObject();
            var x = o as IDictionary<string, object>;
            foreach (string propName in whitelist)
            {
                var prop = input.GetType().GetProperty(propName);
                if (prop != null)
                {
                    x[propName] = prop.GetValue(input, null);
                }
            }
            return o;
        }
    }
