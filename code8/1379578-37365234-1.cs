    using (MySqlConnection con = new MySqlConnection(""))
    {
        con.Open();
        string sql = "SELECT first_name,last_name,username,contact_number,address,email FROM user_tbl WHERE user_type='2'";
        MySqlCommand cmd = new MySqlCommand(sql, con);
    
        try
        {
            DataTable dt = new DataTable();
            using (MySqlDataReader reader1 = cmd.ExecuteReader())
            {
                dt.Load(reader1);
            }
   
            GridView1.DataSource = dt ;
            GridView1.DataBind();
        }
    
        catch (Exception ex)
        {
            lblresult.Text = "ERROR>>" + ex.Message + "!";
        }
    
        finally
        {
            con.Close();
            sql = null;
    
        }
    }
