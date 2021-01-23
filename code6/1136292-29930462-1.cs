    static void Main(string[] args)
    {
       for(int X = 0; X <=5; X++)
       {
         Test _test = new Test();
         _test.A_String = "A" + X.ToString();
         _test.B_String = "B" + X.ToString();
         _dict.Add(X, _test);
         // each _test goes out of scope here
       }
       _dict.Remove(2);
       // Removed from dictionary, have no way to access it now.
