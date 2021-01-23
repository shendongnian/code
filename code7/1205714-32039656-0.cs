    public List<Comment> Comments
    {
        get
        {
            return _ticket.Comments.AsReadOnly();
        }
    }
