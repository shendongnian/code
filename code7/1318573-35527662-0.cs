    public static string TransformJson(string originalJson)
    {
        return new JArray(
            JObject.Parse(originalJson).Properties().Select(jp => 
            {
                var jo = new JObject((JObject)jp.Value);
                jo.AddFirst(new JProperty("name", jp.Name));
                return jo;
            })
        ).ToString();
    }
