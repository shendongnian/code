    static void Main()
    {
      AnotherClass a = new AnotherClass();
      try
      {
        a.Say();
      }
      finally
      {
        if (a != null)
        {
          ((Idisposable)a).Dispose();
        }
      }
    }
