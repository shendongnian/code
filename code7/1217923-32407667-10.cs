    public bool IsAuthenticated
    {
        get
        {
            return(_context.User != null 
                   && _context.User.Identity != null 
                   && _context.User.Identity.IsAuthenticated);
        }
    }
