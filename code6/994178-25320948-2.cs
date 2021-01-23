    string id;//declare it as global
    private void dtgRecord_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        if (e.RowIndex >= 0) {
            DataGridViewRow row = this.dtgRecord.Rows[e.RowIndex];
            id = row.Cells["id"].Value.ToString();
            txtUsername.Text = row.Cells["username"].Value.ToString();
            txtPassword.Text = row.Cells["password"].Value.ToString();
            txtPosition.Text = row.Cells["position"].Value.ToString();
        }
    }
