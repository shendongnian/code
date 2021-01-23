     var csv =  File
       .ReadLines(@"C:\MyFile.csv")
       .Select(line => line.Split(',')) // the simplest, just to show the idea
     Dictionary<String, String[]> Externals = new Dictionary<String, String[]>();
    
     foreach (var items in csv) {
       var key = items[0]; // let External_ID be the 1st column
       var value = items;  // or whatever record representation
    
       if (!Externals.ContainsKey(key)) 
         Externals.Add(key, value);
       // else {
       //   //TODO: implement, if you want to deal with duplicates in some other way 
       //}
     }
   
