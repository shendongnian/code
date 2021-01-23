    protected void btnOrderNow_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow g1 in GridView1.Rows)
        {
            string sss = (((Label)(g1.Cells[g1.RowIndex].FindControl("lblSession"))).Text.Trim());
            int uuu = int.Parse(((Label)(g1.Cells[g1.RowIndex].FindControl("Label5"))).Text.Trim());
            int itemid = int.Parse(((Label)(g1.Cells[g1.RowIndex].FindControl("lblItemId"))).Text.Trim());
            int priceid = int.Parse(((Label)(g1.Cells[g1.RowIndex].FindControl("lblPriceId"))).Text.Trim());
            int quantity = int.Parse(((Label)(g1.Cells[g1.RowIndex].FindControl("lblItemQuantity"))).Text.Trim());
            int price = int.Parse(((Label)(g1.Cells[g1.RowIndex].FindControl("lblPrice"))).Text.Trim());
            int bprice = int.Parse(((Label)(g1.Cells[g1.RowIndex].FindControl("lblBulkPrice"))).Text.Trim());
    
            val2 = obj4.OrderTempCartUpdate(sss, uuu);
        }
    
    }
