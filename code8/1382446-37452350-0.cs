    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        List<string> objectIdSelected = new List<string>();
        foreach (RepeaterItem oneObject in gwList.Items)
        {
            CheckBox chkObj = (CheckBox)carAd.FindControl("chkObjectSelected");
            if (chkObj.Checked)
            {
                objectIdSelected.Add(chkObj.Attributes["Value"].ToString());
            }
        }
    }
