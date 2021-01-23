    private void insertBTN_Click(object sender, EventArgs e)
    {
        try
        {
            DataRow row = ds.Tables["emp"].NewRow();
            row.SetField<int>("id", int.Parse(textBox1.Text));
            row.SetField<string>("name", textBox2.Text));
            row.SetField<string>("address", textBox3.Text));
            row.SetField<int>("age", int.Parse(textBox4.Text));
            row.SetField<int>("salary", int.Parse(textBox5.Text));
            ds.Tables["emp"].Rows.Add(row);
            adapter.Update(ds,"Emp");
            MessageBox.Show("Employee added successfully");
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
