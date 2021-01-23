    Test(new ViewDataDictionary { { key, value  } }); 
    
    void Test(ViewDataDictionary dictionary) {
         var dic2 = new ViewDataDictionary(dictionary);
         //...
    }
