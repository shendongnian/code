    string constr = ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlConnection con = new SqlConnection(constr);
            string sql1 = "SELECT COUNT (client_id) FROM client WHERE client_id = '" + txtid.Text + "' ";
            SqlCommand cmd = new SqlCommand(sql1, con);
            con.Open();
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
           if (temp >0)
            {
    //show error message
            }
