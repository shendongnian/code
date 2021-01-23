    public override bool MoveNext()
    {
        switch (state)
        {
            case 1:
                enumerator = source.GetEnumerator();
                state = 2;
                goto case 2;
            case 2:
                while (enumerator.MoveNext())
                {
                    TSource item = enumerator.Current;
                    if (predicate(item))
                    {
                        current = item;
                        return true;
                    }
                }
                Dispose();
                break;
        }
        return false;
    }
