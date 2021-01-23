    static string GetText2(ToolStripMenuItem c)
    {
        string s = c.OwnerItem.Text + @"==>" + c.Text + Environment.NewLine;
        foreach (ToolStripMenuItem c2 in c.DropDownItems)
        {
            s += GetText2(c2);
        }
        return s;
    }
