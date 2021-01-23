    //List<string> userDefinedPropeties is a parameter
    List<dynamic> filteredMyObjects = new List<dynamic>();
    foreach (var i in filteredMyObjects)
    {
        dynamic adding = new ExpandoObject();
        foreach (var prop in userDefinedPropeties) 
        {
            adding[prop] = i.GetType().GetProperty(prop).GetValue(i);
        }
        
        filteredMyObjects.Add(adding);
    }
    
    // all of the elements of the filtered list can be accessed by using 
    // item.`PropertyName`
