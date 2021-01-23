    public RequestContext RequestContext
    {
      get
      {
        if (this._requestContext == null)
          this._requestContext = new RequestContext(this.HttpContext ?? (HttpContextBase) new ControllerContext.EmptyHttpContext(), this.RouteData ?? new RouteData());
        return this._requestContext;
      }
      set
      {
        this._requestContext = value;
      }
    }
