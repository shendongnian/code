    public string Name { get; private set; }
            
    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
       Name = dataGridView1.CurrentRow.Cells["clmName"].Value.ToString();
       this.close();
    }
