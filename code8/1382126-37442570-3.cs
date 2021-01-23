       enum SortOrder
        {
            Unknown = 0,
            Ascending = 1,
            Descending = 2
        }
        static bool IsSorted<T>(IEnumerable<T> enumerable)
        {
            var enumerator = enumerable.GetEnumerator();
            // Empty Enumerable
            if (!enumerator.MoveNext())
                return true;
            SortOrder order = SortOrder.None;
            // First Item
            var last = enumerator.Current;
            while(enumerator.MoveNext())
            { 
                var result = Comparer<T>.Default.Compare(last, enumerator.Current);
                switch (order)
                {
                    case SortOrder.Unknown:
                        if (result == 0)
                            break;
                        if(result == -1)
                            order = SortOrder.Ascending;
                        else 
                            order = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        if (result == -1)
                            return false;
                        break;
                    case SortOrder.Ascending:
                        if (result == 1)
                            return false;
                        break;
                }
                last = enumerator.Current;
            }
            
            return true;
        }
