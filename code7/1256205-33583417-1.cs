    protected void DetailsView2_DataBound(object sender, EventArgs e)
        {
            DropDownList ddlDept = (DropDownList)DetailsView2.FindControl("ddlDept");
 
            ddlDept.Items.Insert(0, new ListItem("Select department"));
 
        }
