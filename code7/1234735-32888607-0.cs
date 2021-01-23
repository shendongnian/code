    public static void ProcessJSON(string json)
    {
        User u = new User();
        var test = JsonConvert.DeserializeObject(json);
        if (test.GetType() == typeof(User))
            u = (User)test;
    }
