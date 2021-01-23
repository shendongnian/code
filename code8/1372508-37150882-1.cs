    public bool IsSynchronized 
    {
      get { return false; }
    }
This basically means that the property is there but only when you cast it as ICollection
    var c = new Collection<double>();
    var casted = (ICollection) c;
    var isSync = casted.IsSynchronized;
