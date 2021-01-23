    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string values = this.GetCheckBoxListValues(chkGenderList);
    }
    private string GetCheckBoxListValues(CheckBoxList chkList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (ListItem lst in chkList.Items)
        {
            if (lst.Selected)
                sb.Append(lst.Value).Append(",");
        }
        if (sb.Length > 0)
            sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }
