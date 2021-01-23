    var logsList = ops.ApplyTo(logs, new ODataQuerySettings()).toList();
    // reform logsList
    return MakeGenericResult(logsList.AsQueryable(), logsList.AsQueryable().GetType());
    private IHttpActionResult Ok(object content, Type type)
    {
        var resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);
        return Activator.CreateInstance(resultType, content, this) as IHttpActionResult;
    }
