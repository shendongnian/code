    public static void SetObservableValues<T>(
        ObservableCollection<T> observableCollection,
        IEnumerable<T> values)
    {  
        if (observableCollection != values)
        {
            observableCollection.Clear();
            foreach (var item in values)
            {
                observableCollection.Add(item);
            }
        }
    }
