       private void button1_Click(object sender, EventArgs e)
       {
           sc.Open();
           cmd = new SqlCommand("SELECT maincategory_name FROM maincategory", sc);
           using (var reader = cmd.ExecuteReader()){
               if ( reader.Read() )
               {
                  textBox1.Text = reader.GetString(0);
               }
           };
           sc.Close();
       }
