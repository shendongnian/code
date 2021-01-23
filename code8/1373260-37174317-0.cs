    this.gridpandl.DataSource = ... your get data source routine....
    this.gridpandl.DataBind();
    lbltotal.Text = SumRows();
    ....
    private decimal SumRows()
    {
        decimal total = 0;
        for (int index = 0; index < this.gridpandl.Rows.Count; index++)
            total += Convert.ToDecimal(this.gridpandl.Rows[index].Cells[2].Text);
        return total
    }
    protected void gridpandl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string proid = gridpandl.DataKeys[index].Value.ToString();
        this.gridpandl.Rows[index].Cells[2].Text = GetPurchase(proid);
    }
