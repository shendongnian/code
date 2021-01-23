    public class CollectionMethods
    {
        public static bool AreEquivalent(ICollection expected, ICollection actual)
        {
            //We can do a few quick tests we can do to get a easy true or easy false.
            //Is one collection null and one not?
            if (Object.ReferenceEquals(expected, null) != Object.ReferenceEquals(actual, null))
                return false;
            //Do they both point at the same object?
            if (Object.ReferenceEquals(expected, actual))
                return true;
            //Do they have diffrent counts?
            if (expected.Count != actual.Count)
                return false;
            //Do we have two empty collections?
            if (expected.Count == 0)
                return true;
            //Ran out of easy tests, now have to do the slow work.
            int nullCount1;
            Dictionary<object, int> elementCounts1 = CollectionMethods.GetElementCounts(expected, out nullCount1);
            int nullCount2;
            Dictionary<object, int> elementCounts2 = CollectionMethods.GetElementCounts(actual, out nullCount2);
            //One last quick check, do the two collections have the same number of null elements?
            if (nullCount2 != nullCount1)
            {
                return false;
            }
            //Check for each element and see if we see them the same number of times in both collections.
            foreach (object key in elementCounts1.Keys)
            {
                int expectedCount;
                elementCounts1.TryGetValue(key, out expectedCount);
                int actualCount;
                elementCounts2.TryGetValue(key, out actualCount);
                if (expectedCount != actualCount)
                {
                    return false;
                }
            }
            return true;
        }
        private static Dictionary<object, int> GetElementCounts(ICollection collection, out int nullCount)
        {
            Dictionary<object, int> dictionary = new Dictionary<object, int>();
            nullCount = 0;
            foreach (object key in (IEnumerable)collection)
            {
                if (key == null)
                {
                    ++nullCount;
                }
                else
                {
                    int num;
                    dictionary.TryGetValue(key, out num);
                    ++num;
                    dictionary[key] = num;
                }
            }
            return dictionary;
        }
    }
