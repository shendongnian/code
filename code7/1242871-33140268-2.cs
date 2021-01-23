    using System.Collections.Generic;
    
    ...
    int n = 10;
    List<string> str = new List<string>(); // creates a list of strings
    // List<string> str = new List<string>(n) to set the number it can hold initially (better performance)
    
    for (int i = 0; i < n; i++) {
        list.Add("");
    }
    list[0] = "hello world"; // how to use a List
