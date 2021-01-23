            protected void ddlAccountCode_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
            {
                RadComboBox combo = (RadComboBox)sender;
                combo.ShowDropDownOnTextboxClick = false;
                combo.Items.Clear();
        
                Session["Text"] = e.Text;
                Session["NumberOfItems"] = e.NumberOfItems;
            }
        
            protected void btnSearch_Click(object sender, EventArgs e)
            {
                GridEditableItem editedItem = (sender as Button).NamingContainer as GridEditableItem;
                RadComboBox combo = (RadComboBox)editedItem.FindControl("ddlAccountCode");
                combo.Items.Clear();
                combo.OpenDropDownOnLoad = true; 
                combo.HighlightTemplatedItems = true; 
    
                string c = ddlCompany.SelectedValue.ToString(); //get the selected company name
                string txt = Session["Text"].ToString(); 
        
                DataTable dt = new DataTable();    
                dt = GetAccCode(c);
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("AccountDescription LIKE '%{0}%'", txt);
                int a = dv.Count;
                if (dv.Count > 0)
                {
                    dt = dv.ToTable();
                }
        
                int itemOffset = Convert.ToInt32(Session["NumberOfItems"]);
                int endOffset = Math.Min(itemOffset + ItemsPerRequest, dt.Rows.Count);
                Session["NumberOfItems"] = endOffset == dt.Rows.Count;
        
                for (int i = itemOffset; i < dv.Count; i++)
                {
                    combo.Items.Add(new RadComboBoxItem(dt.Rows[i]["AccountDescription"].ToString(), dt.Rows[i]["AccountDescription"].ToString()));
                }
                   
                Label lbl = (Label)combo.Footer.FindControl("lblRadComboFooter");
                lbl.Text = GetStatusMessage(endOffset, dt.Rows.Count);
        
                combo.DataBind();
            }
