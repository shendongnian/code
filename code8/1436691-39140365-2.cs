    public static bool IsOrdered<T>(this IEnumerable<T> enumerable) where T: IComparable<T>
    {
        using (var enumerator = enumerable.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                return true; //empty enumeration is ordered
            var left = enumerator.Current;
            int previousUnequalComparison = 0;
            while (enumerator.MoveNext())
            {
                var right = enumerator.Current;
                var currentComparison = left.CompareTo(right);
                if (currentComparison != 0)
                {
                    if (previousUnequalComparison != 0
                        && currentComparison != previousUnequalComparison)
                        return false;
                    previousUnequalComparison = currentComparison;
                    left = right;
                }
            }
        }
        return true;
    }
