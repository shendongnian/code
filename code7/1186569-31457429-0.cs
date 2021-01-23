    List<List<string>> a = /*parse ur data to this*/;
    foreach(var pa in a){
      dynamic r = getDynamicObject(pa /*List<string>*/);
      string jsonString = Newtonsoft.Json.SerializeObject(r);
      /*you might have ur string*/
    }
    
    /*separate function*/
    GetDynamicObject(IEnumerable<string> a){
     dynamic r = new ExpandoObject();
     if(a.count > 2){
      return (r as Dictionary<string,  object>).Add(a.First(), GetDynamicObject(a.Skip(1)));
      } 
      else {
        return (r as Dictionary<string,  object>).Add(a.First(), a.Last());
     }
    }
