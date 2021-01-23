    public async Task SomeAsync()
    {
      var request = new MyRequest();
      await request.MakeRequestAsync();
      ...
    }
    public void Start()
    {
      var task = SomeAsync();
      // Now the task is started, and we can use it for future reference. Or just wire up
      // some error handling continuations etc. - though it's usually a better idea to do that
      // within SomeAsync directly.
    }
