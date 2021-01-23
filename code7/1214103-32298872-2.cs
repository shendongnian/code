     Func<string, int> action = (str) => { return MethodToBePassed(str); };
    
     public int MethodToBePassed(string sample)
     {
        return 1;
     }
        
     public static void Test(string a, Func<string, int> action)
     {
        int value = action("a");
     }
 
