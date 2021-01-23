    //RedComboBox 'selectedIndexChanged' event
    protected void CompanyChanged(object sender, EventArgs e)
    {
        RadComboBox CompanyComboBox = fvIPRForm.FindControl("ddlCompany") as RadComboBox;
    
        if (CompanyComboBox.SelectedValue == null || CompanyComboBox.SelectedValue == "")
        {
            RadGrid grid = fvIPRForm.FindControl("RGGSTAcCode") as RadGrid;
            GridCommandItem cmditem = (GridCommandItem)grid.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            System.Web.UI.WebControls.Button ctrl = (System.Web.UI.WebControls.Button)cmditem.FindControl("AddNewRecordButton");
            ctrl.Enabled = false;
    
            System.Web.UI.WebControls.LinkButton btn = (System.Web.UI.WebControls.LinkButton)cmditem.FindControl("InitInsertButton");
            btn.Enabled = false;
    
            string content = "Please select company first";
            ScriptManager.RegisterStartupScript(this, typeof(string), "Successful", "alert('" + content + "');", true);
        }
        else
        {            
            //else code here
        }
    }
    
    //Disable Account Code functionality, If company is not selected
    protected void RGGSTAcCode_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "InitInsert")
        {
            RadComboBox CompanyComboBox = fvIPRForm.FindControl("ddlCompany") as RadComboBox;
    
            if (CompanyComboBox.SelectedValue == null || CompanyComboBox.SelectedValue == "")
            {
                e.Canceled = true;
    
                RadGrid grid = fvIPRForm.FindControl("RGGSTAcCode") as RadGrid;
                GridCommandItem cmditem = (GridCommandItem)grid.MasterTableView.GetItems(GridItemType.CommandItem)[0];
                System.Web.UI.WebControls.Button ctrl = (System.Web.UI.WebControls.Button)cmditem.FindControl("AddNewRecordButton");
                ctrl.Enabled = false;
    
                System.Web.UI.WebControls.LinkButton btn = (System.Web.UI.WebControls.LinkButton)cmditem.FindControl("InitInsertButton");
                btn.Enabled = false;
    
                string content = "Please select company first";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Successful", "alert('" + content + "');", true);
            }
        }
    }
