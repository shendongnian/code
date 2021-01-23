    public int? CurrentScore
    {
        get
        {
            if (TotalCount > 0)
            {
                return (int)((TotalScore * 100) + 0.505m);
            }
            else
            {
                return null;
            }
        }
        set
        {
            //Due to the fact WCF will fail with ReadOnly properties.
        }
    }
