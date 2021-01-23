    public static class IEnumerableExtensions
    {
        public static bool IsSubset<T>(this IEnumerable<T> subsetEnumerable, IEnumerable<T> enumerable)
        {
            var found = false;
            var list = enumerable as IList<T> ?? enumerable.ToList();
            var listCount = list.Count();
            var subsetList = subsetEnumerable as IList<T> ?? subsetEnumerable.ToList();
            var posListCount = subsetList.Count();
			/* If the SubList is bigger, it can't be a sublist */
            if (listCount < posListCount) { 
                return false;
			}
			/* find all indexes of the first item of the sublist in the list */
            var firstElement = subsetList.First();
            var indexes = new List<int>();
            var index = 0;
            foreach (var elem in list)
            {
                if (elem.Equals(firstElement))
                {
                    indexes.Add(index);
                }
                index++;
            }
			/* check all first item founds for the subsequence */
            foreach (var i in indexes)
            {
                int x=0;
                for (x = 0; x < posListCount && (i + x) < listCount; x++)
                {
                    if (!Equals(subsetList[x], list[(i + x)]))
                    {
                        found = false;
                        break;
                    }
                    found = true;
                }
                if (x + 1 < posListCount)
                    found = false;
            }
            return found;
        }
    }
