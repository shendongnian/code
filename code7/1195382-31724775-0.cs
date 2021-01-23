    private void button2_Click(object sender, EventArgs e
    {
       conn.Open();
       com.Connection = conn;
    
       sql = "SELECT COUNT(*) FROM lapusers WHERE [username] = @username";
       com.CommandText = sql;
       com.Parameters.Clear();
       com.Parameters.AddWithValue("@username", userlapbox.Text);
       int numRecords = (int)com.ExecuteScalar();
    
       if (numrecords == 0)
       {
          sql = "INSERT INTO lapusers([username],[fillingcode],[branch],[department],[agency])VALUES(@username,@fillingcode,@branch,@department,@agency)";
          com.CommandText = sql;
          com.Parameters.Clear();
          com.Parameters.AddWithValue("@username", userlapbox.Text);
          com.Parameters.AddWithValue("@fillingcode", userfilllapbox.Text);
          com.Parameters.AddWithValue("@branch", comboBox2.Text);
          com.Parameters.AddWithValue("@department", comboBox1.Text);
          com.Parameters.AddWithValue("@agency", comboBox3.Text);
          com.ExecuteNonQuery();
          MessageBox.Show("Created Successfully ..");      
       }
       else
       {
          MessageBox.Show("A record with a user name of {0} already exists", userlapbox.Text);
       }
    
       conn.Close();
    }
