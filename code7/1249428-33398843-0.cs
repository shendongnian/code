    interface IStrategyResult
    {
        Type ReturnType { get; }
    }
    interface IStrategyResult<T> : IStrategyResult
    {
        // your code here
    }
