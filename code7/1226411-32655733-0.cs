    SqlConnection con=new SqlConnection("connection Strin");
    DataSet ds = new DataSet(); 
    SqlCommand cmd = new SqlCommand("SEARCH", con); 
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@City_Id",DropDownList4.SelectedValue.ToString());
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(ds);
    Session["sessDataSet"] = ds; 
    Response.Redirect("Search_Basic.aspx");
