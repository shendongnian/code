    using System.Collections.Generic;
    
    ...
    int n = 10;
    List<string> str = new List<string>(); // creates a list of strings
    // List<string> str = new List<string>(n) to set the number it can hold initially (better performance)
    
    for (int i = 0; i < n; i++) {
        list.Add(""); // if you've set an initial capacity to a list, be aware that elements will go after the pre allocated elements
    }
    list[0] = "hello world"; // how to use a List
    list[list.Count - 1] = "i am the last element"; // list.Count will get the total amount of elements in this list, and we minus 1 to fix indexing
