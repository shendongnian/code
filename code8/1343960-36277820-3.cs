    var wrapper = objectContent.Value as IWrapper;
    if (wrapper != null)
    {
        actionExecutedContext.Response.Content = new ObjectContent(wrapper.Data.GetType(), wrapper.Data, formatter);
    }
