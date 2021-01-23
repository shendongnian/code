     using (SqlConnection con = new SqlConnection(ConString))
    
        {
    
            CmdString = "SELECT FROM WolfAcademyForm WHERE [Forename] == " + txtSearch.Text + ";"
            SqlCommand cmd = new SqlCommand(CmdString, con);
    
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
    
            DataTable dt = new DataTable("Employee");
    
            sda.Fill(dt);
    
            grdSearch.ItemsSource = dt.DefaultView;
    
        }
