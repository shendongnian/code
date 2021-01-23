    DataTable dtSelect = dataView.ToTable(true, "item", "subItem");
    DGV.AutoGenerateColumns = true;
    DGV.DataSource = dtSelect;
    // Create the column and insert it as the first column
    DataGridViewButtonColumn cl = new DataGridViewButtonColumn();
    cl.HeaderText = "Button column";
    DGV.Columns.Insert(0, cl);
    // Add the CellFormatting event to be able to change the button text
    DGV.CellFormatting += DGV_CellFormatting;
    .....
    void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0)
           e.Value = "Click Me";
    }
