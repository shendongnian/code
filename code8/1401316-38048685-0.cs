    var checkList = new CheckBoxList();
    checkList.AutoPostBack = true;
    checkList.CssClass = "name";
    checkList.RepeatDirection = RepeatDirection.Vertical;
    foreach (DataRow dr in exemption)
    {
        string option = dr["Betoption"].ToString();
        string optionID = dr["id"].ToString();
    
        checkList.Items.Add(new ListItem()
        {
            Text = option,
            Value = optionID
        });
    
    }
    
    PlaceHolder1.Controls.Add(checkList);
