          protected void btnNext_Click(object sender, EventArgs e)
          {
            if (Session["USER_ID"] != null )
            {
                SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Student;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into Survey (Q1,Q1_Comments) values (@Q1,@Q1_Comments)", con);
                cmd.Parameters.AddWithValue("Q1", radListQ1.SelectedValue);
                cmd.Parameters.AddWithValue("Q1_Comments", txtQ1Comments.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
         }
