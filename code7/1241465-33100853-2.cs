    string abc = "AC";
    var field = typeof (DumbTable).GetField(abc, BindingFlags.Static | BindingFlags.NonPublic);
    if (field == null) 
    {
        // throw Exception, probably
    } else {
        var value = field.GetValue(null);
    }
   
