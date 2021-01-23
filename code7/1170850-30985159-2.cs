     SqlConnection con = new SqlConnection("Data Source=JAYI-PC\\SQLEXPRESS; 
        Initial Catalog=db-ub;Integrated Security=True");
        try
        {
            con.Open();
          string cat = null;
            SqlCommand cmd = new SqlCommand(@"SELECT Username,Password,Category
            FROM Logins WHERE Username=@uname and
            Password=@pass", con);
            cmd.Parameters.AddWithValue("@uname", textBox_usern.Text);
            cmd.Parameters.AddWithValue("@pass", textBox_pwd.Text);
           
            SqlDataReader rdr = cmd.ExecuteReader();  
            //int result = (int)cmd.ExecuteScalar();
        
           int result = 0;
           while(rdr.Read()
         {
           result++; //to confirm it entered while loop so data is there
           cat = rdr[2].ToString();
            
         }
        
            if (result > 0)
            {
                if (cat == "Admin")//this one will chek whether user is admin or
                                     user
                {
                    MessageBox.Show("Welcome Admin");
                    Admin f1 = new Admin();
                    f1.Show();
                }
        
                else
                {
                    MessageBox.Show("Welcome " + textBox_usern.Text);
                    FormCheck f3 = new FormCheck();
                    f3.Show();
                }
            }
        
            else
            {
                MessageBox.Show("Incorrect login");
            }
            textBox_usern.Clear();
            textBox_pwd.Clear();
