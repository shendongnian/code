    private void A()
    {
      if(_someField == null)
        throw new InvalidOperationException("field not ready");
      _someField.DoSomething();
    }
    private void B()
    {
      A();
    }
    private void C()
    {
      B();
    }
    private string D()
    {
      try
      {
        C();
      }
      catch(InvalidOperationException)
      {
        Console.Error.WriteLine("Was not ready");
      }
    }
