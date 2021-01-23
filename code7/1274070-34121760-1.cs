    private void button_Click(object sender, EventArgs e)
    {
        var button = sender as Button;
        foreach (DataGridViewRow item in this.dataGridView1.Rows)
        {
            //This is the last row, ignore it.
            if (item.IsNewRow)
                continue;
            
            //Compare value of cell1 with button text
            //I supposed button.Tex is the value that you want to compare with cusid 
            if (item.Cells[1].Value.ToString() == button.Text)
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
