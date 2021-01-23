        foreach(var key in wmDictionary.Keys)
     {
       switch (key)
       {
         string originalVal = wmDictionary[key].Value;
         string newVal = originalVal.replace("&","");
         wmDictionary[key] = newVal
       }
     }
