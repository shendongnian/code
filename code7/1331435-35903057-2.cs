     public static class IEnumerableExtensions
        {
            public static bool EqualTo<T>(this IEnumerable<T> enumerable, IEnumerable<T> other)
            {
                //reference equal 
                if (other == enumerable)
                {
                    return true;
                }
    
                if (other == null)
                {
                    return false;
                }
    
                var enumerableSorted = enumerable.ToArray();
                var otherSorted = other.ToArray();
    
                //No need to iterate over items if lengths are not equal
                if (otherSorted.Length != enumerableSorted.Length)
                {
                    return false;
                }
    
                Array.Sort(enumerableSorted);
                Array.Sort(otherSorted);
    
                return !enumerableSorted.Where((t, i) => t.Equals(otherSorted[i])).Any();
            }
        }
