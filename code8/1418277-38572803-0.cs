    private int? total;
    public int Total
    {
        get
        {
            return total ?? sub_total_1 + sub_total_2;
        }
        protected internal set
        {
            total = value;
        }
    }
