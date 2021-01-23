    class SomeClass
    {
      public string term;
      public bool Predicate(string o)
      {
        return o.Contains(term.Trim());
      }
    }
