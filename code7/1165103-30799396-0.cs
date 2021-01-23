    Dictionary<string, ApplicationClass> dictionary = new Dictionary<string, ApplicationClass>();
    for(int i = 0; i < 4; i++) {
        dictionary.Add("something" + i, new xxx.ApplicationClass());
    }
    var myApplicationClass = dictionary["something1"];
