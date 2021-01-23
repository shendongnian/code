    public class Level1
    {
       public int a;
      public  int b;
        public string c;
        
        public virtual string GetString()
        {
          return c;
        }
    }
    // inherits from Level1
    public class Level2a : Level1
    {
       public string d;
       public bool e;
        public override string GetString()
        {
          return base.GetString() + d ;
        }    
    }
    public class Level2b : Level1
    {
       public int f;
       public bool g;
      
    }
-----
    Level1 obj= new Level2a();
     ....
    Console.WriteLine(obj.GetString());
     // This is my string
    obj= new Level2b();
    .....
    Console.WriteLine(obj.GetString());
    // This is
