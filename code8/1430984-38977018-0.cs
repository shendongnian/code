    /// <summary>Get a hashable / comparable key representing the current parameters.</summary>
    /// <returns>The hash key.</returns>
    public virtual object GetHashKey()
    {
        return new { Param1, Param2, Param3, Param4, ..., ParamN };
    }
