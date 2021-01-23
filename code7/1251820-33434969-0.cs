    static void Main()
    {
      string json = "{\"FullName\":\"Mr Ravikanth\",\"LastName\":Yavathae}";
        JObject parsed = JObject.Parse(json);
        foreach (var pair in parsed)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }
