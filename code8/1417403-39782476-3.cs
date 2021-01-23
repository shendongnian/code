    // Used to generate model type names like "Collection of {MyType}" instead of "Collection of Object".
    if (!modelType.IsGenericType                                // Model type must not be a generic type.
        && modelType.BaseType != null                           // Model type must have a base type (i.e. the model type is a derived type).
        && modelType.BaseType.IsGenericType                     // Model type base type must be a generic type.
        && typeof(IList).IsAssignableFrom(modelType.BaseType))  // Model type base type must implement the IList interface (you can replace "IList" by "IEnumerable" to be more general).
    {
        // Set the model type to the model type base type and the rest of the method will know what to do.
        modelType = modelType.BaseType;
    
    }
