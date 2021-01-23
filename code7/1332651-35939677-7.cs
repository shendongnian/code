    List<string> list = new List<string> { "..." };
    using (List<string>.Enumerator enumerator = list.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            string item = enumerator.Current;
            Console.WriteLine(item);
        }
    }
