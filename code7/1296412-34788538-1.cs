    private void Delete_Click(object sender, EventArgs e)
    {
        YourDialog dlg = new YourDialog();
        DialogResult dialogResult = dlg.ShowDialog();
        if(dialogResult == DialogResult.OK)
        {
            if (this.dgvTable.SelectedRows.Count > 0)
                    {
                        dgvTable.Rows.RemoveAt(this.dgvTable.SelectedRows[0].Index);
                    } 
        }
        else if (dialogResult == DialogResult.Cancel)
        {
            return;
        }
    }
