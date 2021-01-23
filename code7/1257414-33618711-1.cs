    public PupJointRating(SecondFormParams secondFormParams)
    {
        InitializeComponent();
        string tensCap = String.Format("{0:N0}", secondFormParams.ArgumentOne);
        DisplayTensCap.Text = tensCap;
        //Do something with other params, like: secondFormParams.ArgumentTwo
    }
