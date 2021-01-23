    public ObservableCollection<MyType> DataTypeValues
    {
       get
       {
          return Enum.GetValues(typeof(MyType)).Cast<MyType>().ToList<MyType>();
       }
    }
