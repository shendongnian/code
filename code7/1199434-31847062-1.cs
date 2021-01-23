    static public void MyReset(this object col)
    {
        Console.WriteLine("Not a collection!");
    }
    static public void MyReset<T>(this ICollection<T> col)
    {
        col.Clear();
        Console.WriteLine("Cleared!");
    }
    static public void MyReset<T>(this IWhateverYouLike<T> col)
    {
        col.ClearItIfYouLike();
        Console.WriteLine("Cleared!");
    }
