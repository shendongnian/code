    static void Main() {        
        string text = "attachment; filename=\"fname.ext\"; param1=\"A\"; param2=\"A\";";
       
        var cp = new ContentDisposition(text);       
        Console.WriteLine("FileName:" + cp.FileName);        
        foreach (DictionaryEntry param in cp.Parameters) {
            Console.WriteLine("{0} = {1}", param.Key, param.Value);
        }        
    }
    // Output:
    // FileName:"fname.ext" 
    // param1 = "A" 
    // param2 = "A"  
