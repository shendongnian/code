     using (SqlConnection a = new SqlConnection(@"Connection"))
        {
            SqlCommand o = new SqlCommand("Select * from Log where Username='" + TextBox3.Text + "' And Password='" + TextBox5.Text + "';", a);
            a.Open();
            SqlDataReader r = o.ExecuteReader(); 
            if (r.Read())
            {
                Response.Redirect("Aspxpage.aspx");
            }
            else
            {
                //-- show Error 
            }
        }
