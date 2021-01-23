    public static IEnumerable<T> IterateWhileMutating<T>(
        this ObservableCollection<T> list)
    {
        int i = 0;
        NotifyCollectionChangedEventHandler handler = (_, args) =>
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (args.NewStartingIndex <= i)
                        i--;
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (args.NewStartingIndex <= i)
                        i--;
                    if (args.OldStartingIndex <= i) //note *not* else if
                        i++;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (args.OldStartingIndex <= i)
                        i++;
                    break;
                case NotifyCollectionChangedAction.Reset:
                    i = int.MaxValue;//end the sequence
                    break;
                default:
                    //do nothing
                    break;
            }
        };
        try
        {
            list.CollectionChanged += handler;
            for (i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }
        finally
        {
            list.CollectionChanged -= handler;
        }
    }
