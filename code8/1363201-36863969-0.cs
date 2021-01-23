    public static string GetFullMethodName(Action action)
    {
      return string.Format("{0}.{1}", action.Method.DeclaringType.Name, action.Method.Name);
    }
    var strConcrete = GetFullMethodName(concrete.Method).Dump(); // Sandbox.Concrete.Method
    var strContract = GetFullMethodName(contract.Method).Dump(); // Sandbox.Concrete.Method
