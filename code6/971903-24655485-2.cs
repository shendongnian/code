    string json = "[[0,1,2,3,4],[5,6,7,8,9],[10,11,12,13,14]]";
    var tests = JsonConvert.DeserializeObject<JArray>(json)
        .Cast<JArray>()
        .Select(a => new Test { 
             Example = (int)a[0],
             Example2 = (int)a[1]
             // etc
        });
