    private UserProfile commenter;
    public virtual UserProfile Commenter
    {   
        get
        {
            return commenter;
        }
        set 
        {
            CommenterName = (value == null ? string.Empty : value.DisplayName);
            commenter = value;
        } 
    }
