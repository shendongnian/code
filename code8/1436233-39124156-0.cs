    var props = typeof(Location).GetProperties();
    string json = File.ReadAllText(@"C:\file.json");
    JavaScriptSerializer ser = new JavaScriptSerializer();
    var dict = ser.Deserialize<Dictionary<string, object>>(json);
    foreach (var outer in dict)
    {
        foreach (var middle in (Dictionary<string, object>)outer.Value)
        {
            foreach (var inner in (ArrayList)middle.Value)
            {
                foreach (var loc in (Dictionary<string, object>)inner)
                {
                    var location = new Location();
                    var prop = props.FirstOrDefault(p => p.Name.ToUpper() == loc.Key.ToUpper());
                    if (prop != null)
                    {
                        prop.SetValue(location, loc.Value);
                    }
                    
                }
            }
        }
    }
