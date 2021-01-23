    public PupJointRating(double adjTens, double secondParam)
    {
        InitializeComponent();
        Convert.ToString(adjTens);
        string tensCap = String.Format("{0:N0}", adjTens);
        DisplayTensCap.Text = tensCap;
        //do something with secondParam
    }
