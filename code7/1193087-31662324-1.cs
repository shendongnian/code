    private string[] parameterObjectToStringArray(object parameters, params string[] toAdd) {
        var properties = parameters.GetType().GetProperties();
        List<string> p = new List<string>(properties.Length);
        p.AddRange(toAdd);
        foreach(var prop in properties) {
            string propName = prop.Name;
            if (propName.StartsWith("__"))
            {
                propName = "$$" + propName.Substring(2);
            }
            string line = string.Format("{0}={1}", propName, prop.GetValue(parameters, null));
            p.Add(line);
        }
        return p.ToArray();
    }
