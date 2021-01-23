      protected void btndias_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                int id = Convert.ToInt32(Session["pa_id"]);
                if (note_di.Text.Length != 0)
                {
                    string insert_dim2 = "insert into P_dimensions (P_Id,Height,Weight,Note_dim) values (@pa_id, @height, @weight,@note_dim) ";
                    SqlCommand com2 = new SqlCommand(insert_dim2, conn);
                    com2.Parameters.AddWithValue("@pa_id", id);
                    com2.Parameters.AddWithValue("@height", txbdi2.Text);
                    com2.Parameters.AddWithValue("@weight", txbdi1.Text);
                    com2.Parameters.AddWithValue("@note_dim", note_di.Text);
                    com2.ExecuteNonQuery();
                }
                else
                {
                    string insert_dim1 = "insert into P_dimensions (P_Id,Height,Weight) values (@pa_id, @height, @weight) ";
                    SqlCommand com = new SqlCommand(insert_dim1, conn);
                    com.Parameters.AddWithValue("@pa_id", id);
                    com.Parameters.AddWithValue("@height", txbdi2.Text);
                    com.Parameters.AddWithValue("@weight", txbdi1.Text);
                    com.ExecuteNonQuery();
                }
                
                Response.Write("<script>alert('Τα στοιχεία αποθηκεύτηκαν επιτυχώς!')</script>");
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error :" + ex.ToString());
            }
        }
