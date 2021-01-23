    public static Dictionary<string, PropertyModifier> objProfileSelections = new Dictionary<string, PropertyModifier>();
    public static MyUserProfile Profile; //Assuming this is the object you want to modify
    public static string MySelections(string key)
    {
        PropertyModifier myIncome = new PropertyModifier(text => Profile.MyAnnualIncome = text);
        PropertyModifier interestIncome = new PropertyModifier(text => Profile.InterestAnnualIncome.Add(text)); 
        objProfileSelections.Add("1", myIncome.With("No Answer"));
        objProfileSelections.Add("3", myIncome.With("Less Than $25,000"));
        ...
        objProfileSelections.Add("2", interestIncome.With("No Answer"));
        objProfileSelections.Add("4", interestIncome.With("Less Than $25,000"));
        ...
    }
