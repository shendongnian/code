    public static void Meth_del()
    {
       int x,y;
       MyDel _delegate;
       _delegate = Add;
       Console.WriteLine( _delegate(5,4));
       _delegate += Sub;
       Console.WriteLine( _delegate(5,4));
    }
