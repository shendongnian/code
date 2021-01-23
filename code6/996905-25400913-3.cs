    class Point(int X, int Y) { public int X => 15; }
    
    ==>
    class Point(int X, int Y)
    {
       public int X => 15;
       public int Y {get; set;} = Y;
    }
