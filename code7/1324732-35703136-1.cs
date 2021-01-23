      public enum Status {
        One = 100,
        Another = 200
      }
....
      if (some condition)
        return Status.One;
      else
        return Status.Another;
