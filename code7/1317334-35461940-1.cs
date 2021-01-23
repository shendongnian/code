    var root = JObject.Parse(json);
    var matches = root.DescendantsAndSelf()
                      .OfType<JObject>()
                      .Where(x => x["xid"] != null && x["xid"].ToString() == "5555");
    foreach (JObject jo in matches)
    {
        jo.Add("NewNode", new JObject(new JProperty("SomeProperty", "value")));
    }
    Console.WriteLine(root.ToString());
