    public Form1()
    {
        InitializeComponent();
        // attach handler
        dgvNOPDocs.RowsAdded += GridOnRowsAdded;
        // test
        dgvNOPDocs.Rows.Add("Stuff");
        dgvNOPDocs.RowCount = 3;
    }
    private void GridOnRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        // hide rows
        for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
        {                
            if (dgvNOPDocs.Rows[i].IsNewRow == false)
                dgvNOPDocs.Rows[i].Visible = false;
        }
    }
