    int[] t1 = new int[] { 0, 2 };
    List<int[]> trash = new List<int[]>()
    {
        t1,
        new int[] {0,2},
        new int[] {1,0},
        new int[] {1,1}
    };
    List<int[]> trash2 = new List<int[]>()
    {
        new int[] {0,1},
        new int[] {1,0},
        new int[] {1,1}
    };
    
    Console.WriteLine(trash.Count + "");//Count = 4
    trash.RemoveAll(a => trash2.Any(b => b.SequenceEqual(a)));
    Console.WriteLine(trash.Count + "");//Count = 2
