    var enumerable = Enumerable.Range(0, 10);
    
    var buffer = new List<int>();
    
    using (var enumerator = enumerable.GetEnumerator())
    {
        if (enumerator.MoveNext())
        {
            buffer.Add(enumerator.Current);
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                buffer.Add(current);
        
                Handle(buffer[0], current);
            }
        }
    }
    
    for (int i = 1; i < buffer.Count - 1; i++)
        for (int j = i + 1; j < buffer.Count; j++)
            Handle(buffer[i], buffer[j]);
