    public static List<T> Method<T>(this List<T> list, Func<T, bool> predicate)
    {
        return list.Where(predicate).ToList();
    }
    
    List<int> ints = new List<int>(new int[] { 1, 2, 3, 4, 5 });
    ints = ints.Method(i => i > 2);
    foreach(int item in ints) Console.Write(item + " ");
