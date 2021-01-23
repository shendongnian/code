        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if(e.KeyCode == Keys.Delete)
            {
                foreach(DataGridViewCell cell in dgv.SelectedCells)
                {
                    if (!cell.ReadOnly)
                    {
                        cell.Value = "";
                    }
                }
            }
        } 
