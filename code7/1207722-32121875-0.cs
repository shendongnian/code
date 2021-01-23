    string id="hi";
            connection.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            string query1 = "select * from products where category='" + comboBox1.Text + "' and subcategory = '" + comboBox2.Text + "' and sizes='" + comboBox3.Text + "'";
            command1.CommandText = query1;
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                id = reader[0].ToString();
            }
            textBox1.Text = id;
            ////////code for closing the reader/////////////
            reader.Close();
            ///////////////
            string query = "insert into category_in  (category_id,amount,amount_in) values ('"+ id+"' ,500,300)";
            command1.CommandText = query;
            command1.ExecuteNonQuery();
            MessageBox.Show("saved");
            connection.Close();
