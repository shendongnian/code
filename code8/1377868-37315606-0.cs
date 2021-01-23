    int t;
    try
    {
       int a = 842673832;
       int b = 2131231321;
    
       t = checked(a * b);
    }
    catch (System.OverflowException e)
    {
       t = Int32.MaxValue;
    }
