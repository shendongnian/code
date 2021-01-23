    public static string BuildJson(Dictionary<string, string> dict)
    {
        dynamic expando = new ExpandoObject();
        foreach (KeyValuePair<string, string> pair in dict.Where(x => !string.Equals(x.Key, "path")))
        {
            string[] pathArray = pair.Key.Split('.');
            var currentExpando = expando as IDictionary<string, Object>;
            foreach (string item in pathArray)
            {
                if (string.Equals(item, pathArray.Last()))
                {
                    currentExpando.Add(item, pair.Value);
                }
                else
                {
                    if (!currentExpando.Keys.Contains(item))
                    {
                        currentExpando.Add(item, new ExpandoObject());
                    }
                    currentExpando = currentExpando[item] as IDictionary<string, Object>;
                }
            }
        }
        JObject o = JObject.FromObject(expando);
        return o.ToString();
    }
