            DataTable dt = new DataTable();
            OleDbCommand command = new OleDbCommand();
            string afspraken = "select * from Appointments where PersonID = '" + textBox4.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            foreach (DataRow Dr in dt.Rows)
            {
                listBox1.Items.Add(Dr["COLUMNNAME"].ToString());
            }
            con.Close(); 
