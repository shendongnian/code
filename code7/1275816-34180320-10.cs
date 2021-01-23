    Test(new ViewDataDictionary { { key, value  } }); 
    
    void Test(ViewDataDictionary dictionary) {
         var dic2 = new ViewDataDictionary();
         // ... initialize dic2
         foreach (var pair in dictionary)
         {
                dic2.Add(pair);
         }
    }
