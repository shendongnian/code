    public static async Task<MyObject> getObject()
    {
      if (NotOkFromSomeReason())
      {
        return Task.FromResult<MyObject>(null);
      }
      return myDataBase.FindAsync(something);
    }
