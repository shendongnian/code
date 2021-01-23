    public static string ConvertUserToFlattenedJson(User u)
    {
        var flattenedUser = new
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            Sport = u.Likes.Select(l => l.Sport).First(),
            Food = u.Likes.Select(l => l.Food).First(),
            Music = u.Likes.Select(l => l.Music).First(),
            Place = u.Likes.Select(l => l.Place).First(),
        };
    
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(flattenedUser);
        return json;
    }
