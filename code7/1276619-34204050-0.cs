    public Tbl_name GetValueFromTable()
    {
        var selectedCode = Convert.ToInt32(RadioButtonList.SelectedValue);
        return dbo.Tbl_name.Single(q => q.Code = selectedCode);
    }
