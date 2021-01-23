    public static Func<int, List<Vector>> one(int foo, int bar)
    {
        Func<int, List<Vector>> func =
            num =>
            {
                List<Vector> v = new List<Vector>();
                for (int i = 0; i < num; i++)
                {
                    v.Add(new Vector(1 + foo, 1 + bar));
                }
                return v;
            };
    
        return func;
    }
