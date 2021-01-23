    private void button1_Click(object sender, EventArgs e)
    {
        List<string> lst = new List<string>();
        foreach (DataGridViewRow row in dgvInfo.SelectedRows)
        {
            var Value = row.Cells["Description"].Value.ToString();
            if (!string.IsNullOrWhiteSpace(Value))
            {
                lst.Add(Value);
            }
        }
        Form4 fr = new Form4(lst);
        fr.ShowDialog();
    }
