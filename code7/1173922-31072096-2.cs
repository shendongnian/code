    public void Main() // Your main method
    {
      mymethod("fff", 2); // Will call first mymethod
      mymethod(2.13, "ff"); // Will call second mymethod
    }
    void mymethod(string str, int intvar)
    {
      Console.WriteLine("m1"); 
    }
      
    void mymethod(double flt, string stringvar)
    {
      Console.WriteLine("m2"); 
    }
