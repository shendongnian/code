    public static void While(List<int> x)
    {        
        using (var enumerator = x.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                int item = enumerator.Current;
                Console.WriteLine(item);
            }
        }
    }
