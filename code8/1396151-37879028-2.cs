            public IEnumerable RangeBetween()
            {
                foreach (var i in Enumerable.Range(1, 20))
                {
                    if (i < 6 || i > 8)
                    {
                        yield return i;
                    }
                }
            }
