       private void firearmView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!firearmView.Rows[e.RowIndex].IsNewRow)
            {
                selectedFirearmPictureBox.Image = Image.FromFile(firearmView.Rows[e.RowIndex].Cells[12].Value.ToString(), true);
            }
        }
          
