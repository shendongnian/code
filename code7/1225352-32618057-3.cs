    var ttt =  GetTheData();
    
    foreach (var t in ttt)
    {
        var properties = t.GetType().GetProperties();
        foreach(var p in properties){
           if(p.PropertyType.Name.Equals("String")){
              if(p.GetValue(t,null).ToString() == "NULL")
                 p.SetValue(t,string.Empty,null);
           }
        }
    }
