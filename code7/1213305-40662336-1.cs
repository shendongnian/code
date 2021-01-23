    public static class OracleFunctions
    {
       [Function(FunctionType.BuiltInFunction, "TO_NUMBER")]
       public static int? ToNumber(this string value) => Function.CallNotSupported<int?>();
    }
