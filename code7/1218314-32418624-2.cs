    using System;
    using System.Collections.Generic;
    static void Main()
    {
        var list = new List<int>{ 1,2,3,4,5};
        foreach(var x in list) // foreach grabs old list and keeps it
        {
            Console.WriteLine(x);
            list = new List<int>{9,9,9}; // replace the whole list
        }
    }
