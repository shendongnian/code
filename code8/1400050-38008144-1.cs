    if (CheckboxID.Items.Any(x => x.Selected))
    {
        List<string> conditionList = new List<string>();
        foreach (ListItem item in CheckboxID.Items.Where(x => x.Selected))
        {
            conditionList.Add(" SousRubrique Like '%" + item.Value + "%' ");
        }
        strSql += " AND (" + string.Join(" OR ", conditionList) + "  )";
    }
