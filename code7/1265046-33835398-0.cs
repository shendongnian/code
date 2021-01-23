    public static void Meth_del()
    {
       int x,y;
       MyDel _delegate;
       _delegate = Add;
       // Prints out 9.  
       Console.WriteLine( _delegate(5,4));
       // Override subscribtion.
       _delegate = Sub;
      // Prints out 1.
      Console.WriteLine( _delegate(5,4));
    }
