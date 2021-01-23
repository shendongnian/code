    SqlConnection con = new SqlConnection(@"server=.;database=test;integrated security=false;user id=sa;pwd=@admin00");
            con.Open();
            SqlCommand sqlcom = new SqlCommand("select book_id,book_name from Table_book", con);
            SqlDataReader sqlDR=sqlcom.ExecuteReader();
            while(sqlDR.Read())
            {
            listBox1.Items.Add(sqlDR["book_id"].ToString()+"-"+sqlDR["book_name"].ToString());
            }
