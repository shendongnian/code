    private Books() { }
    public static Books CreateFromComments()
    {
        var ret = new Books();
        ret.CommentsList = new List<Comments>();
        return ret;
    }
    public static Books CreateFromRatings()
    {
        var ret = new Books();
        ret.RatingsList = new List<Ratings>();
        return ret;
    }
