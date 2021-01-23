        static bool DebugValidateSort<T>(IList<T> list, IComparer<T> comparer)
        {
            for (int i = 0, count = list.Count; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (Math.Sign(i - j) != Math.Sign(comparer.Compare(list[i], list[j])))
                    {
                        Debug.Assert(false, string.Format("Bad sort found at {0} and {1}", i, j));
                        return false;
                    }
                }
            }
            return true;
        }
