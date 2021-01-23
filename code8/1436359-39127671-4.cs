    public bool ExitMethod() { throw new ExitParentMethodException(); }
    public void SomeMethod()
    {
      try
      {
        ExitMethod();
        Console.WriteLine("Test");
      }
      catch (ExitParentMethodException) { }
    }
