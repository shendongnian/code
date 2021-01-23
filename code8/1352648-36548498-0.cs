    const string InsertStatement1 = @"INSERT INTO tbl_inv (cname, date, duedate, subtotal, vat, total) 
        VALUES (@cname, @date, @duedate, @subtotal, @vat, @total);";
    const string InsertStatement2 = @"INSERT INTO tbl_line (invno, pname, qty, unitprice, amount) 
        VALUES (@invno, @pname, @qty, @unitprice, @amount);";
    
    cn.Open();
    using (MySqlTransaction sqlTrans = cn.BeginTransaction())
    using (MySqlCommand sqlCommand = new MySqlCommand(InsertStatement1, cn, sqlTrans))
    {
        sqlCommand.Parameters.Add("@cname", comboBox1.Text);
        sqlCommand.Parameters.Add("@date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        sqlCommand.Parameters.Add("@duedate", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
        sqlCommand.Parameters.Add("@subtotal", textBox6.Text);
        sqlCommand.Parameters.Add("@vat", textBox7.Text);
        sqlCommand.Parameters.Add("@total", textBox9.Text);
        sqlCommand.ExecuteNonQuery();
    
        sqlCommand.Parameters.Clear();
        sqlCommand.CommandText = "SELECT LAST_INSERT_ID();";
        var o = sqlCommand.ExecuteScalar();
        if (o is Int64)
        {
            var id = (Int64)o;
            foreach (DataGridViewRow row in mg2.Rows)
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@invno", id);
                sqlCommand.Parameters.AddWithValue("@pname", row.Cells[1].Value);
                sqlCommand.Parameters.AddWithValue("@qty", row.Cells[2].Value);
                sqlCommand.Parameters.AddWithValue("@unitprice", row.Cells[3].Value);
                sqlCommand.Parameters.AddWithValue("@amount", row.Cells[4].Value);
                sqlCommand.CommandText = InsertStatement2;
    	        sqlCommand.ExecuteNonQuery();
            }
        }
        sqlTrans.Commit();
    }
