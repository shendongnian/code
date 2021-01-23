    // declare the items, no need to set values
    public enum FavoriteFruits {
        Banana,
        Apple, }
    // bind the enum to the control
    RadioButtonList1.DataSource = Enum.GetValues(typeof(FavoriteFruits)); 
    RadioButtonList1.DataBind();
    
    // this is needed because SelectedValue gives you a string...
    var selectedValue = (FavoriteFruits)Enum.Parse(typeof(FavoriteFruits), 
       RadioButtonList1.SelectedValue, true); 
    //...then you can do a switch against your enum
    switch (selectedValue )
    {
        case FavoriteFruits.Apple:
            doStuffForApple();
            break;
        case FavoriteFruits.Banana:
           doStuffForBanana();
           break;
    }
