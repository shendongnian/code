    Object obj = new int[] { 1, 2, 3, 4 };
    IEnumerable collection = obj as IEnumerable;
    IEnumerable<int> integers = collection.Cast<int>();
    foreach(int i in integers)
        System.Console.WriteLine(i);
