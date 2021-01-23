    var lines = new MyPoco[6000];
    for (int i = 0; i < lines.Length; i++)
    {
        lines[i] = new MyPoco
        {
            op = "Concatenate" + i,
            left = "Integer",
            right = "String",
            result = "String",
        };
    }
    var json = JsonConvert.SerializeObject(lines, Formatting.Indented);
    File.WriteAllText("JsonNet.json", json);
    var json2 = new JavaScriptSerializer().Serialize(lines);
    File.WriteAllText("JavaScriptSerializer.json", json2);
