    protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
       
           try
           {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
            
            SqlCommand cmd = new SqlCommand("INSERT INTO TEST (name,fathername) VALUES('" + TextBox1.Text + "','" + TextBox1.Text + "')", con);
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
