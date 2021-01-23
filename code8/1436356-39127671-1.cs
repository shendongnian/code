    public enum ExitParentStatus : byte
    {
      Continue, Return
    }
    public ExitParentStatus ExitMethod() => // ...
    public void SomeMethod()
    {
      if (ExitMethod() == ExitParentStatus.Return) return;
      Console.WriteLine("Test");
    }
