            public IEnumerable RangeBetwean()
            {
                foreach (var i in Enumerable.Range(0, 100))
                {
                    if (i < 6 || i > 8)
                    {
                        yield return i;
                    }
                }
            }
