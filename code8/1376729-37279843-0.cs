    if (chkName.Checked && Name.Text.Length > 0)
    {
        query = query.Where(s => s.Name == Name.Text);
    }
    if (chkSName.Checked && Sname.Text.Length > 0)
    {
        query = query.Where(s => s.Sname == Sname.Text);
    }
    if (chkClassList.Checked && ClassList.Text.Length > 0)
    {
        query = query.Where(s => s.ClassList == ClassList.Text);
    }
