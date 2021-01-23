    public IEnumerable<int> AllIDs
    {
      get
      {
        yield return Id;
    
        foreach(var child in C1)
        {
          yield return child.Id;
        }
    
        foreach(var child in C2)
        {
          yield return child.Id;
          yield return child.C3.Id;
        }
      }
    }
