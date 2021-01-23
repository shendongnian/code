    if (CheckboxID.Items.Any(x => x.Selected))
    {
        strSql +=" AND (";
    
        foreach (ListItem item in CheckboxID.Items)
        {
            if (item.Selected)
            {
                selectedValue =  item.Value ;
                if (IsFirst)
                    strSql += " OR ";
               
                strSql += " SousRubrique Like '%" + selectedValue + "%' ";
                IsFirst = true; 
            }
        }
        strSql += @"  )";
    }
