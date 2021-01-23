    protected void RGGSTAcCode_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                //bind dropdwon while "Add" 
                string CompanyCode = ddlCompany.SelectedValue.ToString();
                GridEditableItem item = (GridEditableItem)e.Item;
    
                if (!(e.Item is IGridInsertItem))
                {
                    RadComboBox rcb = (RadComboBox)item.FindControl("ddlAccountCode");
    
                    //bind combobox in Edit mode from DB when using LoadOnDemand
                    RadComboBoxItem rcbi = new RadComboBoxItem();
                    rcbi.Text = ((DataRowView)e.Item.DataItem)["AccountCode"].ToString() + '-' + ((DataRowView)e.Item.DataItem)["AccountDescription"].ToString();
                    rcbi.Value = ((DataRowView)e.Item.DataItem)["AccountCodeID"].ToString();
                    rcb.Items.Add(rcbi);
                    rcbi.DataBind();
                }
            }
        }
