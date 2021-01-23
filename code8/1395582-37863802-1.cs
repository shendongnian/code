    public static string ChangeNumericalPropertyNames(JsonReader reader)
    {
        JObject jo = JObject.Load(reader);
        foreach (JProperty jp in jo.Properties().ToList())
        {
            if (Regex.IsMatch(jp.Name, @"^\d"))
            {
                string name = "n" + jp.Name;
                jp.Replace(new JProperty(name, jp.Value));
            }
        }
        return jo.ToString();
    }
