    public static IEnumerable<T> IterateWhileMutating<T>(this ObservableCollection<T> list)
    {
        int i = 0;
    
        list.CollectionChanged += (_, args) =>
        {
            switch (args.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (args.NewStartingIndex <= i)
                        i--;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    if (args.NewStartingIndex <= i)
                        i--;
                    if (args.OldStartingIndex <= i) //note *not* else if
                        i++;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (args.OldStartingIndex <= i)
                        i++;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    i = int.MaxValue;//end the sequence
                    break;
                default:
                    //do nothing
                    break;
            }
        };
    
        for (i = 0; i < list.Count; i++)
        {
            yield return list[i];
        }
    }
