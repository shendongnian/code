    public void ExecuteConditionalCoroutine(IEnumerable<bool> coroutine)
    {
      foreach (var result in coroutine)
      {
        if (result) return;
      }
    }
    public bool ExitMethod() => // ...
    public IEnumerable<bool> SomeMethod()
    {
      yield return ExitMethod();
      Console.WriteLine("Test");
    }
    ExecuteConditionalCoroutine(SomeMethod());
