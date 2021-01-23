      public enum Status {
        One = 100,
        Another = 200
      }
....
      if (some condition)
        return Statuses.One;
      else
        return Statuses.Another;
