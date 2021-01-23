    /// <summary>
    /// Configures the TableHiLoGenerator by reading the value of <c>table</c>, 
    /// <c>column</c>, <c>max_lo</c>, and <c>schema</c> from the <c>parms</c> parameter.
    /// </summary>
    /// <param name="type">The <see cref="IType"/> the identifier should be.</param>
    /// <param name="parms">An <see cref="IDictionary"/> of Param values that are keyed by parameter name.</param>
    /// <param name="dialect">The <see cref="Dialect.Dialect"/> to help with Configuration.</param>
    public override void Configure(IType type, IDictionary<string, string> parms, Dialect.Dialect dialect)
    {
        base.Configure(type, parms, dialect);
        maxLo = PropertiesHelper.GetInt64(MaxLo, parms, Int16.MaxValue);
        lo = maxLo + 1; // so we "clock over" on the first invocation
        returnClass = type.ReturnedClass;
    }
