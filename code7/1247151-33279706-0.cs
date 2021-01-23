    public class Parameters
    {
      private readonly IDictionary<string, string> _parameters;
      public Parameters(IDictionary<string, string> parameters)
      {
        _parameters = parameters;
      }
      public string this[string key]
      {
        get { return _parameters[key]; }
      }
    }
