    private void button1_Click(object sender, EventArgs e)
    {
        const int checkBoxPosition = 3; //You must type here the position of checkbox.
                                        // Remember, it's zero based.
        StringBuilder ln = new StringBuilder();
        dataGridView1.ClearSelection();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
          if (row.Cells[checkBoxPosition].Value == true)
            {                    
                ln.Append(row.Cells[1].Value.ToString());
            }
            else
            {
                MessageBox.Show("No row is selected!");
                break;                    
            }
        }
        MessageBox.Show("Row Content -" + ln);
    }
