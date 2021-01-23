    private void btnMaterialAdd_Click(object sender, EventArgs e)
    {
        TextBox tbTotalCost = new TextBox();
        tbTotalCost.Location = new Point(652, RowCount * 22);
        tbTotalCost.Width = 60;
        txtTotalCost.Add(tbTotalCost);
        tbTotalCost.MouseClick += tbTotalCost_TextChanged;
        panel1.Controls.Add(tbTotalCost);
        tbTotalCost_TextChanged(tbTotalCost, null);  // <-- this line.
     }
