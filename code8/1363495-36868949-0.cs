    List<string> selectedProIDs = gridpur.Rows.Cast<GridViewRow>()
        .Select(row => new { 
            CheckBox = (CheckBox)row.FindControl("chkSel"),
            ProID = gridpur.DataKeys[row.RowIndex].Value.ToString()
        })
        .Where(x => x.CheckBox.Checked)
        .Select(x => x.ProID)
        .ToList();
    StoreClass s = new StoreClass();
    gridpur.DataSource = s.SearchPurchase(hdnSearchParam.Value, txtsearch.Text);
    gridpur.DataBind();
    
    foreach(GridViewRow row in gridpur.Rows)
    {
         var checkBox = (CheckBox)row.FindControl("chkSel");
         string proID = gridpur.DataKeys[row.RowIndex].Value.ToString();
         checkBox.Checked = selectedProIDs.Contains(proID);
    }
