    private void button_Click(object sender, EventArgs e)
    {
        var button = sender as Button;
        foreach (DataGridViewRow item in this.dataGridView1.Rows)
        {
            if (item.IsNewRow)
                continue;
            
            if (item.Cells[0].Value.ToString() == button.Text)
            {
                //Make row editable
                item.ReadOnly = false;
                //Select the logout cell
                this.dataGridView1.CurrentCell = item.Cells[5];
            }
            else
            {
                //Make row readonly
                item.ReadOnly = true;
            }
        }
    }
