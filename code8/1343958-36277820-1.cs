    object value = objectContent.Value;
    if (value != null && value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(Wrapper<>))
    {
        object data = ((dynamic)value).Data;
        actionExecutedContext.Response.Content = new ObjectContent(data.GetType(), data, formatter);
    }
