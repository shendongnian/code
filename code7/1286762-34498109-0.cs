    private void btnSbmt_Click(object sender, EventArgs e)
    {
        // This removes whatever is in the lists 
        _MyName.Clear();
        _MyAmount.Clear();
        _MyPrice.Clear();       
        // and now start adding items from scratch
        foreach (var row in radGridView1.Rows)
        {
            _MyName.Add((string)row.Cells[1].Value);
            _MyAmount.Add((int)row.Cells[2].Value);
            _MyPrice.Add((decimal)row.Cells[3].Value);
        }
        ....
