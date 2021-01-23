    try
      {
       DateTime dat = this.dateTimePicker1.Value.Date;
       DateTime dat2 = this.dateTimePicker2.Value.Date;
       // MessageBox.Show(dat.ToShortDateString() + "  " + dat2.ToShortDateString());
       connection1.Open();
       OleDbCommand command = new OleDbCommand();
       command.Connection = connection1;
       string query;
       query = "select * from client_table Where DATEE Between #" + dat.ToLongDateString() +"# and #" + dat2.ToLongDateString() + "# ";
       command.CommandText = query;
       OleDbDataAdapter da = new OleDbDataAdapter(command);
       DataTable dt = new DataTable();
       da.Fill(dt);
       dataGridView1.DataSource = dt;
       connection1.Close();
       }
     catch (Exception ex)
       {
         MessageBox.Show("Error" + ex);
       }
