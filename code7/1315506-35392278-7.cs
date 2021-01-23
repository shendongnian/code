    protected void btn_Click(object sender, EventArgs e)
    {
        List<int> checkedIds = new List<int>();
        foreach(GridViewRow row in gridView.Rows.OfType<GridViewRow>()
            .Where(x => x.RowType == DataControlRowType.DataRow))
        {
            var hiddenId = (HiddenField)row.Cells[0].FindControl("hiddenId");
            var checkBox = (CheckBox) row.Cells[0].FindControl("chb");
            if (checkBox.Checked)
                checkedIds.Add(int.Parse(hiddenId.Value));
        }
    }
