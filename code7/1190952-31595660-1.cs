    static void Main(string[] args)
    {
        var lineitem = new LineItem();
        var items = new[]
        {
        new Invoice{id=1, value =30, li = new List<LineItem>{lineitem}}, //<-- like this
        new Invoice{id=2, value =10},
        new Invoice{id=3, value =20}
        };
    }
