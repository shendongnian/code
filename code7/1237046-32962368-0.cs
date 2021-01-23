        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DbEmployee;Integrated Security=SSPI;");
        SqlCommand cmd = new SqlCommand("Select * from tbl_EmpDetails", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        string JSONresult;
        JSONresult = JsonConvert.SerializeObject(dt);  
        Response.Write(JSONresult);
