    public static string BuildJson(Dictionary<string, string> dict)
    {
        dynamic expando = new ExpandoObject();
        foreach (KeyValuePair<string, string> pair in dict.Where(x => !string.Equals(x.Key, "path")))
        {
            string[] pathArray = pair.Key.Split('.');
            var currentExpando = expando as IDictionary<string, Object>;
            for (int i = 0; i < pathArray.Count(); i++)
            {
                if (i == pathArray.Count() - 1)
                {
                    currentExpando.Add(pathArray[i], pair.Value);
                }
                else
                {
                    if (!currentExpando.Keys.Contains(pathArray[i]))
                    {
                        currentExpando.Add(pathArray[i], new ExpandoObject());
                    }
                    currentExpando = currentExpando[pathArray[i]] as IDictionary<string, Object>;
                }
            }
        }
        JObject o = JObject.FromObject(expando);
        return o.ToString();
    }
