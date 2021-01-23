      enum SortOrder
        {
            None = 0,
            Ascending = 1,
            Descending = 2
        }
        static bool IsSorted<T>(IEnumerable<T> enumerable)
        {
            var enumerator = enumerable.GetEnumerator();
            // Empty Enumerable
            if (!enumerator.MoveNext())
                return true;
            // First Item
            var last = enumerator.Current;
            if (!enumerator.MoveNext())
                return true;
            int result = Comparer<T>.Default.Compare(last, enumerator.Current) + 1;
            last = enumerator.Current;
            SortOrder order = SortOrder.None;
            while (enumerator.MoveNext())
            {
                var newResult = Comparer<T>.Default.Compare(last, enumerator.Current);
                switch (order)
                {
                    case SortOrder.None:
                        if (newResult == result)
                            break;
                        if(newResult < result)
                            order = SortOrder.Ascending;
                        else 
                            order = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        if (newResult < result)
                            return false;
                        break;
                    case SortOrder.Ascending:
                        if (newResult > result)
                            return false;
                        break;
                }
                last = enumerator.current;
                result = newResult;
            }
            
            return true;
        }
