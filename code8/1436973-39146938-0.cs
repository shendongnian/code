    List<MyObject> lst = new List<MyObject>(); // fake dbSet can be Queryable
    
    int[] toto =   lst.Take(60).Select(item => item.MyInt).ToArray();
    
    
    private class MyObject
    {
        public int MyInt { get; set; }
    }
