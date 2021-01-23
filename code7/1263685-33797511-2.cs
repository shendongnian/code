    c.connect();
    comm = new OracleCommand(); /*Class OracleCommand  represents an SQL statement or stored procedure to execute against a database. OracleCommand() initializes a new instance of the OracleCommand. */
    comm.Connection = c.conn;
    comm.CommandText = "INSERT INTO bus VALUES (@bus_no, @jdate, @source, @destination, @departtime)";
    comm.Parameters.Add("@bus_no",  busno.Text);
    comm.Parameters.Add("@jdate", dateTimePicker1.Value);
    comm.Parameters.Add("@source", source.Text);
    comm.Parameters.Add("@destination", destination.Text);
    comm.Parameters.Add("@departtime", departtime.Text);
    comm.ExecuteNonQuery();
    MessageBox.Show("Bus Added");
    c.conn.Close();
