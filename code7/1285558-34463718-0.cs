    var dict = JsonConvert.DeserializeObject<dynamic>(agents);
    List<string> results = new List<string>();
    foreach (var d in dict)
    {
        List<string> skills = new List<string>();
        foreach (var s in d["Skills"])
        {
            skills.Add(s["SN"].ToString() + "-" + s["SL"].ToString());
        }
        string skill = string.Join(",", skills);
        string list = d["Id"] + "/" + d["Name"] + "/" + skill;
        results.Add(list);
    }
    string result = string.Join(";", results);
