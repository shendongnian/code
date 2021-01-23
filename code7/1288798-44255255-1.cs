        internal ReadOnlyObservableCollection
            ( ICompositeList<T> list
            , System.Collections.ObjectModel.ObservableCollection<T> collection
            , IEqualityComparer<T> eq
            ) : base(collection)
        {
            _List = list;
            _Collection = collection;
            _Disposable = list.ChangesObservable(eq)
                .Subscribe(change =>
                {
                    int i = 0;
                    foreach (var diff in change)
                    {
                        switch (diff.Operation)
                        {
                            case DiffOperation.Match:
                                break;
                            case DiffOperation.Insert:
                                _Collection.Insert(i, diff.ElementFromCollection2.Value);
                                break;
                            case DiffOperation.Delete:
                                _Collection.RemoveAt(i);
                                i--;
                                break;
                            case DiffOperation.Replace:
                                _Collection[i] = diff.ElementFromCollection2.Value;
                                break;
                            case DiffOperation.Modify:
                                _Collection[i] = diff.ElementFromCollection2.Value;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        i++;
                    }
                });
        }
 
