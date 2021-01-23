    public void H1(int a, int b, int c, int d) 
    {
        // NOTE: this is just an example, I'd normally use an OR mapper!
        // Construct query using a,b,c
        string baseQuery = ConstructQuery(a,b,c);
        baseQuery += " and d = " + d.ToString();
        // ...
        ExecuteSql(baseQuery);
        // ...
    }
