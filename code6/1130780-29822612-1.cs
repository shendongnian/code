     if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //foreach( GridViewRow row in GridView1.Rows)
                    //{
                        String ItemCode = (e.Row.FindControl("lbl_ItemCode") as Label).Text;
                           
                        if ( ItemCode == "SUBFREQ")
                        {
                            List<Entities.ItemValues> PGItemValues = new List<Entities.ItemValues>();
    
                            TextBox TextBoxtemp = ((TextBox)e.Row.FindControl("txtPrice"));
    
                            TextBoxtemp.Visible = false;
    
                            Label lbel = ((Label)e.Row.FindControl("lbl_IsPercentbased"));
    
                            lbel.Visible = false;
    
                            CheckBox chk = ((CheckBox)e.Row.FindControl("ChkIsPercent"));
    
                            chk.Visible = false;
    
                            DropDownList dd1 = ((DropDownList)e.Row.FindControl("ddFrequencyBilling"));
    
                            dd1.Visible = true;
    
                            PGItemValues = BLL.PriceGroupItemValues.GetItemValueOnCode(ItemCode, 1);
    
                            dd1.DataSource = PGItemValues;
    
                            dd1.DataTextField = "IValue";
    
                            dd1.DataValueField = "ItemCode";
    
                            dd1.DataBind();
                        }
                    //}
                }
