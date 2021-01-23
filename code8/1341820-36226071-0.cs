    void Main()
    {
        Dictionary<string, testClass> test = new Dictionary<string, testClass>();
    
        string key = "key";
        testClass val = null;
        //val now holds a null reference
    
        test.Add(key, val);
        //You add a null reference to the dictionary
    
        val = new testClass();
        //Now val holds a new reference for testClass, while the dictionary still has null
    
        test[key].Dump(); //returns null.   WHAT? I just set it!!!
        //Now it returns the null reference which you just added to the dictionary
    
    
        test[key] = val;
        //Now the dictionary holds the same reference as val
    
        val.Text = "something";
        //You set the Text of the val, and the dictionary-held value, because they're the same
        
        //  returns val object, with Text set to "Something". 
        //  If the above didn't work, why does this work?
        test[key].Dump(); 
        // I think now you know why..
    
        //...
    }
