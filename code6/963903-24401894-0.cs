    protected void Button1_Click(object sender, EventArgs e)
        {
           try
           {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("INSERTINTO TEST (name,fathername) VALUES('" + TextBox1.Text + "','" + TextBox1.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();           
           }
        catch(Exception ex)
        {
        String ErrorMsg=ex.ToString();
        }
       finally
       {
           con.Close();
       }
        }
