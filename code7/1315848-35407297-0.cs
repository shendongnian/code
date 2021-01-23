    public static int Comparisons;
    
    public static LinkedListNode<T> GetMiddle<T>(LinkedListNode<T> Head) where T : IComparable<T>
    {
        // ...
        Comparisons++;
        if (Left.Value.CompareTo(Right.Value) <= 0)
        // ...
    }
