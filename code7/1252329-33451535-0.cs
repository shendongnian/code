    var myArr = new int[] { 2, 1 };
    List<int[]> ListOfArrays = new List<int[]>();
    ListOfArrays.Add(new int[] { 1, 1 });
    ListOfArrays.Add(new int[] { 4, 1 });
    ListOfArrays.Add(new int[] { 1, 1 });
    ListOfArrays.Add(new int[] { 2, 1 });
    
    int index = ListOfArrays.FindIndex(l => Enumerable.SequenceEqual(myArr, l));
