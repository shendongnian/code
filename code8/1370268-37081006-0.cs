    foreach (var key3 in globalDict.Keys)
    {
         foreach (var key2 in globalDict[key3].Keys)
         {
             Console.WriteLine("Jours {0}", key2);
             foreach (var key1 in globalDict[key3][key2].Keys) // here
             {
                  Console.WriteLine(globalDict[key3][key2][key1]);
             }
         }
    }
