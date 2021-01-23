    //using Newtonsoft.Json;
    
    List<MyObject> objects = new List<MyObject>();
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        MyObject obj = new MyObject()
        obj.Time = dt.Rows[i]["Time"];
        obj.Person = dt.Rows[i]["PersonID"];
        ...
        objects.Add(obj);
    }
                
    string json = JsonConvert.SerializeObject(objects.ToArray());
