    public bool SomeMethod
    {
      get { /* some code */ }
      set
      {
        AsyncMethod().Wait();
      }
    }
    public async Task AsyncMethod() {}
