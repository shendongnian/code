    public static string ConvertUserToFlattenedJson(User u)
    {
        dynamic flatUser = new ExpandoObject();
        flatUser.FirstName = u.FirstName;
        flatUser.LastName = u.LastName;
        var dict = u.Details as IDictionary<string, Object>;
        foreach (var like in dict)
        {
            ((IDictionary<string, Object>)flatUser)[like.Key] = like.Value;
        }
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(flatUser);
        return json;
    }
