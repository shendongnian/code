    bool firstRun = true;
    foreach(var result in con.Query(comString))
    {
       var rDictionary = (IDictionary<string,object>)result;
       
       //assuming this is what you want based off of your commented out code
       if(firstRun){
           Console.Write(string.Join("|",rDictionary.Keys));
       }
       Console.WriteLine( 
               string.Join("|", rDictionary.Select(a=>a.Value ?? (object)"NULL"))
       );
    }
