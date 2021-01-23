    private void DGV_sourcefolder_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            if (DGV_sourcefolder.Columns[e.ColumnIndex].Name == "Edit")
            {
                string y = "";
                int i;
                i = ((DataGridView)sender).SelectedCells[0].RowIndex;
                y = ((DataGridView)sender).Rows[i].Cells[1].Value.ToString();
                //MessageBox.Show(y.ToString());
                DTO.data = y;
                var row =  ((DataGridView)sender).Rows[i];
                Form2 form = new Form2(row);
                form.Show();
                Hide();
            }
        }
