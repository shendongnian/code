    for (int row = 0; row <  _flex.Rows.Count; row++)
    {
    C1FlexDataTree child = _flex.Rows[row].UserData as C1FlexDataTree;
    if (child != null)
    {
        foreach (Column c in child.Cols)
        {
            c.AllowEditing = false;
        }
    }
    }
