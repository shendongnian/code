    public interface IConnectionSettings
    {
      public ConnectionStringSettings DataWarehouse { get; }
      public ConnectionStringSettings Audit { get; }
      public ConnectionStringSettings Logging { get; }
      public ConnectionStringSettings Security { get; }
    }
