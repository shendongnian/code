    private void dgvSomeGrid_DoubleClick(object sender, EventArgs e)
    {
        string name = dgvSomeGrid.CurrentRow.Cells[5].Value.ToString();
        var result = MessageBox.Show(name, "Select this Merkmal?", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            _someID = Convert.ToInt32(dgvMSomeGrid.CurrentRow.Cells[0].Value.ToString());
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
