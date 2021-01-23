    public class Level1
    {
       public int a;
      public  int b;
        public string c;
        
        public virtual string GetName()
        {
          return "A";
        }
    }
    // inherits from Level1
    public class Level2a : Level1
    {
       public string d;
       public bool e;
        public override string GetName()
        {
          return "B";
        }    
    }
    public class Level2b : Level1
    {
       public int f;
       public bool g;
        public override string GetName()
        {
          return "C";
        }    
    }
-----
    Level1 obj= new Level2a();
    obj.GetName();
     // B
    obj= new Level2b();
    obj.GetName();
   
    // C
