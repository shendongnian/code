    private void populate()
    {
        var obj = new {LevelsConfig = new List<LevelsConfig>() }   
        string json = File.ReadAllText("jsontest");
        JsonConvert.PopulateObject(json, obj);
        foreach (var config in obj.LevelsConfig) 
        {
            // ...
        }
    }
