      double totl = 0;
    
     
    
    protected void lvtest_DataBound(object sender, ListViewItemEventArgs e)
    
    {
    
        if (e.Item.ItemType == ListViewItemType.DataItem)
    
        {
    
            Label lbltotalquantity= e.Item.FindControl("lblquantity") as Label;
    
            totl += Convert.ToDouble(lbltotalquantity.Text);
    
        }
    
    }
    
     
    
    protected void lvtest_PreRender(object sender, EventArgs e)
    
    {
    
        Label lblTot = this.lvProducts.FindControl("lblTotal") as Label;
    
        lblTot.Text = totl.ToString(); ;
    
    }
