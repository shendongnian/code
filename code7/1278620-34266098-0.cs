        void gvPOAdd_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
        
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                if(e.Item.ItemType == ListItemType.Item)
                {
                    TextBox txtQuantity= e.Row.FindControl("txtQuantity") as TextBox;
                    TextBox txtUnitCost= e.Row.FindControl("txtUnitCost") as TextBox;
        
                    txtUnitCost.Attributes.Add("onkeyup", "calculateTotalCharge(this,'" + txtQuantity.Text+ "');");
                }
            }
        }
