    using (var enumerator = GetValues().GetEnumerator()) {
        while(enumerator.MoveNext())
        {
            var value = enumerator.Current;
            Console.WriteLine(value);
        }
    }
