    string strSqlAnd = @" AND (";
    foreach (ListItem item in CheckboxID.Items)
    {
        if (item.Selected)
        {
            selectedValue = item.Value;
            if (IsFirst)
            {
                strSql += " OR ";
            }
            strSql += " SousRubrique Like '%" + selectedValue + "%' ";
            IsFirst = true;
        }
    }
    strSqlAnd += @"  )";
    if (CheckboxID.Items.Any(x => x.Selected))
    {
        strSql += strSqlAnd;
    }
