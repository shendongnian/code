    private void myRepeater_ItemDataBound(object sender, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType !=
           ListItemType.AlternatingItem)
        {
            CustomRadioButton customRbtn = (CustomRadioButton)e.Item.FindControl("RadioButton_Select");
            //Now you have an instance of your eclipse radio button so you can do what you want with it.
        }
    }
