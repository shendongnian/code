    class GOO {
      string author { get; set; }
      string date { get; set; }
      // ...
    }
    class FOO { 
      // ...
    }
    
    object parse(string barcode) {
      int pos = barcode.IndexOf('|');
      string type = barcode.substring(0,pos);
      string obj = barcode.substring(pos+1);
      switch(type) {
       case "GOO": return JsonConvert.DeserializeObject<GOO>(obj);
       case "FOO": return JsonConvert.DeserializeObject<FOO>(obj); 
       default: return null; // unknown type
      }
    }
