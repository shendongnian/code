        private bool AreDictsEqual(IDictionary<string, string[]> d1, IDictionary<string, string[]> d2)
        {
            if (d1.Keys.OrderBy(p => p).SequenceEqual(d2.Keys.OrderBy(p => p)))
            {
                foreach (var item in d1)
                {
                    if (!d2[item.Key].OrderBy(p => p).SequenceEqual(item.Value.OrderBy(p => p)))
                    {
                        return false;
                    }
                }
            }
            return false;
        }
