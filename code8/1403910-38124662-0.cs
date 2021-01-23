    public bool IsAuthenticated
    {
        get
        {
            return this._context.User != null && 
                   this._context.User.Identity != null &&
                   this._context.User.Identity.IsAuthenticated;
        }
    }
