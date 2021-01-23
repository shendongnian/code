    public static class NaturalSortExt
    {
        /// <summary>Sorts a list in "Natural sort order", i.e. "9" sorts before "10".</summary>
        /// <typeparam name="T">The type of elements in the list to be sorted.</typeparam>
        /// <param name="self">The list to be sorted.</param>
        /// <param name="stringSelector">A projection to convert list elements to strings for comparision.</param>
        public static void SortNatural<T>(this List<T> self, Func<T, string> stringSelector)
        {
            self.Sort((lhs, rhs) => StrCmpLogicalW(stringSelector(lhs), stringSelector(rhs)));
        }
        /// <summary>Sorts a list in "Natural sort order", i.e. "9" sorts before "10".</summary>
        /// <param name="self">The list to be sorted.</param>
        public static void SortNatural(this List<string> self)
        {
            self.Sort(StrCmpLogicalW);
        }
        /// <summary>Sorts an array in "Natural sort order", i.e. "9" sorts before "10".</summary>
        /// <param name="self">The array to be sorted.</param>
        public static void SortNatural(this string[] self)
        {
            Array.Sort(self, StrCmpLogicalW);
        }
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        static extern int StrCmpLogicalW(string lhs, string rhs);
    }
