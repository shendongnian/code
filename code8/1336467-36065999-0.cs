    /// <summary>Makes an API call.</summary>
    /// <typeparam name="T">The type returned by the API call.</typeparam>
    /// <param name="param">The parameter passed to the API call.</param>
    /// <returns>The value returned by the API call.</returns>
    public delegate T ApiCall<T>(string param);
