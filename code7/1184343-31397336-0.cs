    protected void RGGSTAcCode_ItemDataBound(object sender, GridItemEventArgs e)
        {
    
           if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    //bind dropdwon while "Add" 
                    string CompanyCode = ddlCompany.SelectedValue.ToString();
                    GridEditableItem item = (GridEditableItem)e.Item;
                    DropDownList ddl = (DropDownList)item.FindControl("ddlAcCode");
                    ddl.DataSource = GetAccCode(CompanyCode);
                    ddl.DataTextField="*your text field*";
                    ddl.DataValueField="*your Value field*";
                    ddl.DataBind();
                    ddl.Items.Insert(0, "- Select -");
    
                    //Select particular dropdown value while "Edit"
                    string accCodeID = item.GetDataKeyValue("AccountCodeID").ToString();
                    Label lblAcCode2 = item.FindControl("lblAcCode") as Label;
    
                    if (!string.IsNullOrEmpty(lblAcCode2.Text))
                    {
                        ddl.SelectedValue = lblAcCode2.Text;
                    }
                    string SelectedVal =  ddl.SelectedValue;
    
                 }
         }
