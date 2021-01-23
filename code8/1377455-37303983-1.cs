    public void PrintsZero()
    {
        List<int> lt1 = new List<int>() { 1, 2, 3, 4 };
        List<int> lt2 = lt1;
        lt1.Clear();
        int xx = lt2.Sum();
        Console.WriteLine(xx);//prints "0"
    }
