        private bool AreDictsEqual(IDictionary<string, string[]> d1, IDictionary<string, string[]> d2)
        {
            if (d1.Keys.SequenceEqual(d2.Keys))
            {
                foreach (var item in d1)
                {
                    if (!d2[item.Key].SequenceEqual(item.Value))
                    {
                        return false;
                    }
                }
            }
            return false;
        }
