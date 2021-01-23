    public abstract class EmployeeHandler
    {
      private readonly EmployeeHandler _nextHandler;
      protected EmployeeHandler(EmployeeHandler nextHandler)
      {
        _nextHandler = nextHandler;
      }
      public string BuildQuery(Employee emp)
      {
        if (CanHandle(emp))
        {
            return GetQuery(emp);
        }
        if (_nextHandler == null)
        {
            return string.Empty;
        }
        return _nextHandler.BuildQuery(emp);
      }
      protected abstract string GetQuery(Employee emp);
      protected abstract bool CanHandle(Employee emp);
    }
