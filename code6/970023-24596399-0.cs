    private List<MyType> _List;
    public ReadOnlyCollection<MyType> RList {
      get {
        return _List.AsReadOnly();
      }
      private set
       {
          _List = value;
       }
    }
