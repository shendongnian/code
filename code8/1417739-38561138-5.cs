    /// <summary>
    /// Gets the <see cref="Http.HttpContext"/> for the executing action.
    /// </summary>
    public HttpContext HttpContext
    {
        get
        {
            return ControllerContext.HttpContext;
        }
    }
