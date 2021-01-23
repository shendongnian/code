    public int SortParam
    {
      get
      { 
        return (new OriginalConverter())
          .Convert(new object[] { Status.Id, Original, Substitution }, typeof(int), null, null); 
      }
    }
