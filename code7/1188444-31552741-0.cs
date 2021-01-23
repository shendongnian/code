    public void UpdateRelatedObject(object source, string sourceProperty, object target)
    {
        ...
        ClientPropertyAnnotation property = parentType.GetProperty(sourceProperty, false);
        if (property.IsKnownType || property.IsEntityCollection)
        {
         throw Error.InvalidOperation(Strings.Context_UpdateRelatedObjectNonCollectionOnly);
        }
        ...
    }
