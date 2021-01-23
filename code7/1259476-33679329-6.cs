    private string _userID;
    public string UserID
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_userID))
                _userID = HttpContext.User.Identity.GetUserId();
            return _userID;
        }
        set { _userID = value; }
    }
