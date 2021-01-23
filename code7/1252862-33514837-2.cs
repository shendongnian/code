    protected void btnsub_Click(object sender, EventArgs e)
            {
                SqlConnection con = Connection.DBconnection();
                if (Textid.Text.Trim().Length > 0)
                {
                    SqlCommand com = new SqlCommand("StoredProcedure3", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", Textid.Text.Trim());
                    com.Parameters.AddWithValue("@Name", Textusername.Text.Trim());
                    com.Parameters.AddWithValue("@Class", Textclass.Text.Trim());
                    com.Parameters.AddWithValue("@Section", Textsection.Text.Trim());
                    com.Parameters.AddWithValue("@address", Textaddress.Text.Trim());
                    com.ExecuteNonQuery();
                    if(!String.InNullOrEmpty(hiddenfield.Value))
                    {
                    int index = Convert.ToInt16(hiddenfield.Value);
                    GridView1.Rows[index].Cells[1].Text = Textusername.Text;
                    GridView1.Rows[index].Cells[2].Text = Textclass.Text;
                    GridView1.Rows[index].Cells[3].Text = Textsection.Text;
                    GridView1.Rows[index].Cells[4].Text = Textaddress.Text;
                    }
    
                }
                else
                {
                    SqlCommand com = new SqlCommand("StoredProcedure1", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Name", Textusername.Text.Trim());
                    com.Parameters.AddWithValue("@Class", Textclass.Text.Trim());
                    com.Parameters.AddWithValue("@Section", Textsection.Text.Trim());
                    com.Parameters.AddWithValue("@address", Textaddress.Text.Trim());
                    com.ExecuteNonQuery();
                    Response.Redirect("studententry.aspx");
                }
            } 
