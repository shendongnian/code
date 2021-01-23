    /// <summary>
    /// Defines a contract for View models that accept parameters
    /// </summary>
    /// <typeparam name="T">Type of argument expected</typeparam>
    public interface IAcceptArguments<in T>
    {
        void Accept(T args);
    }
