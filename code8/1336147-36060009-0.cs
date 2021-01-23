        private int CellSum()
        {
                   string a = string.Empty;
                int sum = 0;
                for (int b = 0; b < dataGridView1.Rows.Count; ++b)
                {
                    try
                    {
                        int d = 0;
                        d += Convert.ToInt32(dataGridView1.Rows[b].Cells[1].Value);
                        sum += d;
                    }
                    catch 
                    {
                        MySqlConnection conn = new MySqlConnection("datasource=localhost;port = 3306;username = root;password = ");
                        MySqlCommand comm = new MySqlCommand("select Miscellaneous_Fee,Amount from system.miscellaneoues;", conn);
                        MySqlDataAdapter ssda = new MySqlDataAdapter();
                        ssda.SelectCommand = comm;
                        DataTable ddbdataset = new DataTable();
                        ssda.Fill(ddbdataset);
                        BindingSource bbsource = new BindingSource();
                        bbsource.DataSource = ddbdataset;
                        dataGridView1.DataSource = bbsource;
                        ssda.Update(ddbdataset);
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        MessageBox.Show("Incorrect Input");
                    }
                }
                return sum;     
          
        }
     private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 1)
                lblMiscellaneous.Text = CellSum().ToString();
        }
