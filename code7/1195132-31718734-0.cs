    var collection = new ObservableCollection<Type>();
    public IEnumerator<Type> GetEnumerator() {
        return collection
            .Where(i => i.Property.State != States.NeedsDelete)
            .GetEnumerator();
    }
