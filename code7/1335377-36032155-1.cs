    public static void Main()
    {
        Action a = new Action(C.Method1);
        a = (Action)Delegate.Combine(a, new Action(C.Method2));
    }
