    void Main()
    {
    	Console.WriteLine (Enum.GetName(typeof(Test),Test.One));
    }
    
    public enum Test
    {
       Zero,
       One,
       Two,
       Uno = 1,
       Dos = 2,
    }
