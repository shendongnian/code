    class Program
    {
        [STAThread()]
        static void Main(string[] args)
        {
            Form f = new Form();
            DataGridView dgv = new DataGridView();
            DataGridViewComboBoxColumn dgvCombo = new DataGridViewComboBoxColumn();
    
            //Setup events
            dgv.CellClick += dgv_CellClick;
    
    
            //Add items to combo
            dgvCombo.Items.Add("Item1");
            dgvCombo.Items.Add("Item2");
    
            //Add combo to grid
            dgv.Columns.Insert(0,dgvCombo);
    
            //Add grid to form
            f.Controls.Add(dgv);
            dgv.Dock = DockStyle.Fill;
            f.ShowDialog(null);
        }
    
        static void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView) sender;
            
            //Check index 0 because the ComboBox is in that column
            if (grid.SelectedCells[0].OwningRow.Cells[0].Value != null)
            {
                MessageBox.Show("A value is selected");
            }
            else
            {
                MessageBox.Show("No Value is selected");
            }
        }
    }
