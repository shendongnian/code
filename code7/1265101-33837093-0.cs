     static IEnumerable<string> Flatten(IEnumerable enumerable)
     {
            foreach (object el in enumerable)
            {
                if (enumerable is IEnumerable<string>)
                {
                    yield return (string) el;
                }
                else
                {
                    IEnumerable candidate = el as IEnumerable;
                    if (candidate != null)
                    {
                        foreach (string nested in Flatten(candidate))
                        {
                            yield return nested;
                        }
                    }
                }
            }
     }
