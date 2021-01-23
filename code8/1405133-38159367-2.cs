    string a = "hello";
    string b = "h";
    
    // Append to contents of 'b'
    b += "ello";
    // When you set the variable's b value to "hello", 
    // this would result in changing the pointer
    // to the object in the HEAP the variable "a" is already pointing to
    // Result would be: (reference of a == reference of b) --> TRUE
    // b = "hello"; 
    
    Console.WriteLine(a == b);                       // value comparison
    Console.WriteLine((object)a == (object)b);       // reference comparison
    Console.WriteLine (object.ReferenceEquals(a,b)); // reference comparison without casting
