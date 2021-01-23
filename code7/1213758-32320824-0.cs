    try
    {
        for (int i = 0; i < dataGridView1.RowCount; i++)
        {
            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txt_FName.Text)
            {
                dataGridView1.Rows[i].Cells[2].Value = [any proccess] ; // Update Row
                return;
            }
        }
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    dataGridView1.Rows.Add(txt_FName.Text, txt_LName.Text, txt_Number.Text); // New Row
