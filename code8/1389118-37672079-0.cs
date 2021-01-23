       protected void ddlproduct_SelcetedIndexChanged(object sender, EventArgs e)
        {
            txtselectedproducts.Text ="";
        
            foreach (ListItem item in (sender as ListControl).Items)
            {
                 if (item.Selected){
                     txtselectedproducts.Text += Item.Text;
                     }
            }
        }
