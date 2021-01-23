    Test(new ViewDataDictionary { { key, value  } }); 
    
    void Test(ViewDataDictionary dictionary) {
         var dic2 = new ViewDataDictionary();
         // ... initialize the dictionary
         foreach (var pair in dictionary)
         {
                dic2.Add(pair);
         }
    }
