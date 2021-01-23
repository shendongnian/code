    public static void Main()
    {
        var filters = new int[][] {
            new int[] { 2, 4 },
            new int[] { 5, 7 },
            new int[] { 9, 10 },
            new int[] { 11, 12 }                
        };
        var newFilter = filters.Select(x => x[0] + "-" + x[1]).ToList();
    
        var answer = context.myClass.Where(x => newFilter.Contains(x.foo + "-" + x.bar)).ToList();
    } 
