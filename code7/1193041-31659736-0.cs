    // using System.Reflection;
    dynamic func = scope.GetVariable("VSH");
    var code = func.__code__;
    var argNamesProperty = code.GetType().GetProperty("ArgNames", BindingFlags.NonPublic | BindingFlags.Instance);
    string[] argNames = (string[])argNamesProperty.GetValue(code, null);
    // argNames = ["GR", "GRsand", "GRshale"]
