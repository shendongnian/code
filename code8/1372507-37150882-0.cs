    public bool IsSynchronized 
    {
      get { return false; }
    }
this basically means that you need to cast it to ICollection then you will see the properties
    var c = new Collection<double>();
    var casted = (ICollection) c;
    var isSync = casted.IsSynchronized;
