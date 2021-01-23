    protected void gridview_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add") {
            TextBox txtAddEmpID = (TextBox)((GridView)sender).FooterRow.FindControl("txtAddEmpID");
        }
    }
