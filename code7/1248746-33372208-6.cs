    Form form = new Form();                // a blank form
    DataGridView DGV = new DataGridView(); // a blank DataGridView
    DGV.Parent = form;                     // we add the DGV to the from
    DGV.AutoGenerateColumns = true;        // to copy all columns from the DataSource
    DGV.DataSource = dt;                   // set the datasource to the table
    form.Width = 500;                      // some size, change to your needs!
    DGV.Dock = DockStyle.Fill;             // the DGV fills the form
            form.ShowDialog();             // we show it as a dialog
