    // <summary>
    // Return the name of a static or instance property from a property access lambda expression.
    // </summary>
    // <typeparam name="T">Type of the property.</typeparam>
    // <param name="propertyLambdaExpression">A lambda expression that refers to a property, in the
    // form: '() => Class.Property' or '() => object.Property'</param>
    // <returns>Return the name of the property represented by the provided lambda expression.</returns>
    internal static string GetPropertyName<T>(System.Linq.Expressions.Expression<Func<T>> propertyLambdaExpression)
    {
        var me = propertyLambdaExpression.Body as System.Linq.Expressions.MemberExpression;
        if (me == null) throw new ArgumentException("The argument must be a lambda expression in the form: '() => Class.Property' or '() => object.Property'");
        return me.Member.Name;
    }
