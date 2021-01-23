    ProductEdit pe = new ProductEdit(dataGridView.SelectedRows[0].Cells[1], dataGridView.SelectedRows[0].Cells[2], dataGridView.SelectedRows[0].Cells[3]);
            
    public ProductEdit(DataGridViewCell PId, DataGridViewCell PName, DataGridViewCell PPrice)
    {
        InitializeComponent();
        txtPId.DataBindings.Add("Text", PId, "Value");
        txtPName.DataBindings.Add("Text", PName, "Value");
        txtPPrice.DataBindings.Add("Text", PPrice, "Value");
    }  
