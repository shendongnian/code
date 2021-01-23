    /// <summary>
    /// Gets or sets the <see cref="ClaimsPrincipal"/> for user associated with the executing action.
    /// </summary>
    public ClaimsPrincipal User
    {
        get
        {
            return Context?.User;
        }
    }
