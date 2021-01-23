           protected void btnQ2Next_Click(object sender, EventArgs e)
           {
              if (Session["USER_ID"] != null)
              {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Student;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UPDATE Survey SET (Q2 = @Q2, Q2_Comments = @Q2_Comments)", con);
            cmd.Parameters.AddWithValue("Q2", radListQ2.SelectedValue);
            cmd.Parameters.AddWithValue("Q2_Comments", txtQ2Comments.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Q3.aspx");
              }
           }
