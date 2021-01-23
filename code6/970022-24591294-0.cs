    public ReadOnlyCollection<ReadOnlyCollection<MyType>> RList {
      get {
        return _List.ConvertAll(list => list.AsReadOnly()).AsReadOnly();
      }
    }
