    private void quantityChangeClick(object sender, EventArgs e)
    {
        addToQuantity((Button)sender == this.Add ? 1 : -1);
        updateTotal();
    }
    private void addToQuantity(int howMuch)
    {
        var selectedRowIndices = dataGridView1.SelectedRows.OfType<DataGridViewRow>().Select(ro => ro.Index);
        this.rows.Where((r, i) => selectedRowIndices.Contains(i)).ToList().ForEach(
            r => r.Quantity = Math.Max(0, r.Quantity + howMuch));
        this.dataGridView1.Refresh();
    }
    // calculate the total from the data source as well
    private void updateTotal()
    {
        var total = Math.Round(this.rows.Sum(r => r.Quantity * r.Price), 2, MidpointRounding.AwayFromZero);
        this.TotalLabel.Text = string.Format("₱{0:0.00}", total);
    }
