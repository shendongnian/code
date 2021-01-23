    //using Newtonsoft.Json.Linq;
    var jsonString = File.ReadAllText(@"C:YourDirectory\file.json"); //source
    var projects = new List<Project>(); //Your result
    JObject data = JObject.Parse(jsonString);
    foreach (var value in data["value"])
    {
        projects.Add(new Project
        {
            Id = value["Id"].ToString(),
            Status = value["Status"].ToString(),
            Title = value["Title"].ToString()
        });
    }
