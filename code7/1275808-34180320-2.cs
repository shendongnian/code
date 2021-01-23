    Test("key", "value"); 
    
    function Test(string key, object value) {
        var dic2 = new System.Web.Mvc.ViewDataDictionary { { key, value  } };
        //...
    }
