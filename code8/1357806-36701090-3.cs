    //calling code makes use of "dynamic" to make things clean and readable.
    dynamic parsedJson = JsonConvert.DeserializeObject(json);
    var allPropAValues = GetPropAValues(parsedJson);
    //**** NOTE: this has our extra property ****
    var jsonWithExtraStuffProperty = JsonConvert.SerializeObject(parsedJson);
    //recursive function that reads AND writes properties
    public static List<string> GetPropAValues(dynamic obj)
    {
        var propAValues = new List<string>();
    
        //**** NOTE: the use of an added property ****
        obj.ExtraStuff = new Random().Next();
    
        //if we have a propA value, get it.
        if (obj.propA != null)
            propAValues.Add(obj.propA.Value);
    
        //iterate through families if there are any. your JSON had Families.Family.
        if (obj.Families != null)
            foreach (dynamic family in obj.Families.Family)
                propAValues.AddRange(GetPropAValues(family));
    
        return propAValues;
    }
                    
