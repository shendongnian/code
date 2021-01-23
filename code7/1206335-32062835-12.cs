    public int SortParam
    {
      get
      { 
        return (bool)(new OriginalConverter())
          .Convert(new object[] { Status.Id, Original, Substitution }, typeof(int), null, null); 
      }
    }
