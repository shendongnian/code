    protected void PostRadButton_Click(object sender, EventArgs e)
                {
                    int p;
                    if (DocStatTxtBox.Text == "2")
                    {
                        foreach (GridDataItem item in RadGrid1.Items)
                        {
                           
                                p = item.RowIndex;
                             
                                Label itemparam = (Label)item["ItemCode"].FindControl("ItemCodeLabel");
                                Label qparam = (Label)item["Quantity"].FindControl("QuantityLabel");
                          
        
                                string itemcodeparam = itemparam.Text;
                                int quantityparam = Convert.ToInt16(qparam.Text);
                                Boolean x = Methods.UpdateStock(WhTxtBoxRadDropDownList.SelectedValue, itemcodeparam, -quantityparam);
                          
                         
                        }
                    }
                }
