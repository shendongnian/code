       private void dgvSomeGrid_DoubleClick(object sender, EventArgs e)
        {
            string name = dgvSomeGrid.CurrentRow.Cells[5].Value.ToString();
            DialogResult = MessageBox.Show(name, "Select this Merkmal?", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                _someID = Convert.ToInt32(dgvMSomeGrid.CurrentRow.Cells[0].Value.ToString());
                formCloseFlag = true;
            }
            return;
        }
