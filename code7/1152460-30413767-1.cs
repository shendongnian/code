    IEnumerable<string> someCollection = whatever;
    {
        IEnumerator<string> enumerator = someCollection.GetEnumerator();
        try
        {
            while( enumerator.MoveNext() )
            {
                string item;  // In C# 4.0 and before, this is outside the while
                item = enumerator.Current;
                {
                    Console.WriteLine(item);
                }
            }
        }
        finally
        {
            if (enumerator != null)
                ((IDisposable)enumerator).Dispose();
        }
    }
