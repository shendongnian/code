    private void EditAdminBtn_Click(object sender, EventArgs e)
    {
        var admin = new EditAdminForm();
        admin.CurrentRow = dataGridView1.CurrentRow;
        admin.ShowDialog();
    }
    // EditAdminForm
    private DataGridRow _currentRow;
    public DataGridRow CurrentRow
    {
        get { return _currentRow; }
        set
        {
            _currentRow = value;
            if (value == null)
            {
                // TODO: Clear form
            }
            else
            {
                usernameTxt.Text = value.CurrentRow.Cells[1].Value.ToString();
                firstnameTxt.Text = value.CurrentRow.Cells[2].Value.ToString();
                surnameTxt.Text = value.CurrentRow.Cells[3].Value.ToString();
                emailTxt.Text = value.Cells[4].Value.ToString();
                statusCombo.Text = value.Cells[6].Value.ToString();
            }
        }
    }
    private void UpdateCurrentRow()
    {
        if (_currentRow == null) return;
        _currentRow.Cells[0].Value = idTxt.Text;
        _currentRow.Cells[1].Value = usernameTxt.Text;
        _currentRow.Cells[2].Value = firstnameTxt.Text;
        _currentRow.Cells[3].Value = surnameTxt.Text;
        _currentRow.Cells[4].Value = emailTxt.Text;
        _currentRow.Cells[6].Value = statusCombo.Text;
    }
    private void SaveBtn_Click(object sender, EventArgs e)
    {
        // Save connection, same as before...
        // then update the row
        UpdateCurrentRow();
        this.Close();
    }
