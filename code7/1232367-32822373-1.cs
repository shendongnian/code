    List<int> vals = new List<int> {1, 1, 2, 2, 3, 4};
    var res = new List<int>();
    foreach (int s in vals.Where(s => 
                           { 
                               Console.WriteLine("lambda"); 
    	                       return s % 2 == 0; 
                           }))
    {
        Console.WriteLine("loop");
    }
