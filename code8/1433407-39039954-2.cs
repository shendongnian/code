        private void cboMonth_TextChanged(object sender, EventArgs e)
        {
           dgvAnnual.DataSource = null;
           dgvAnnual.Rows.Clear();
           dgvAnnual.Columns.Clear();
           BindingSource bSource = new BindingSource();
           bSource.DataSource = ReloadData(dtTable, cboMonth.Text);
           dgvAnnual.DataSource = bSource;
           
           //Using for testing
           Console.WriteLine(dgvAnnual.Columns.Count); //Col = 4
           Console.WriteLine(dgvAnnual.Rows.Count); //Row = 10
           
           //This Code below Working
           string[] str = {"Col1","Col2","Col3","Col4"};
           For(int i = 0;i<dvgAnnual.Columns.Count;i++)
           {
               dvgAnnual.Columns[i].HeaderText = str[i];  //<----- It's ok if it's stay in Loop For, event if I replace i by "0"
           }
        }
