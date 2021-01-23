    public enum StarRating1
    {
        One = 1,
        Two = 2
    }
    public enum StarRating2
    {
        One = StarRating1.One,
        Two = StarRating1.Two
    }
    var sr1 = StarRating1.One;
    var sr2 = (StarRating2) sr1;
