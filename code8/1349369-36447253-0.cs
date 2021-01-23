    protected void gridinvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal Amount = 0;
    
        for (int y = 0; y < gridinvoice.Rows.Count; y++)
        {
            Amount += Convert.ToDecimal(gridinvoice.Rows[y].Cells[4].Text);
        }
    
        if (e.Row.RowType == DataControlRowType.Footer)
        {  
            e.Row.Cells[3].Text = "Amount: <br/> Shipping Cost: <br/> Total Amount:";
            e.Row.Cells[4].Text = Amount.ToString() +"<br/>"+shipping.ToString() +"<br/>" + total.ToString();
        }
    
    }
