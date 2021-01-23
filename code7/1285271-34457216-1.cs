    public static T Get<T>(this String self, T fallBack = default(T))
    {
      try { return (T)Convert.ChangeType(self, typeof(T)); }
      catch { return fallBack; }
    }
