            private void btnupdate_Click(object sender, EventArgs e)
            {
                try
                {
    
                    string c = ConfigurationManager.ConnectionStrings["LMS"].ConnectionString;
                    SqlConnection con = new SqlConnection(c);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("IssueUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", Convert.ToInt32(ComBox1BookID.Text));
                    cmd.Parameters.AddWithValue("@BookName", ComBox2BName.Text);
                    cmd.Parameters.AddWithValue("@DateIssue", IssueDate.Value);
                    cmd.Parameters.AddWithValue("@ReturnDate", ReturnDate.Value);
                    cmd.Parameters.AddWithValue("@PersonID",Convert.ToInt32(CBox3PerID.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    storedproc();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SqlError" + ex);
    
                }
            }
    
