    //partial is only necessary in Database First
    public partial class Foo
    {
       private int _Status = 1;
    
       public int Status
       {
          get{ return _Status; }
          set{ _Status = value; }
       }
    }
