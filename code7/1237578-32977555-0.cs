    protected void Add_Click(object sender, EventArgs e)
    {
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
             //here added "@" to write continuous strind in new line
            SqlCommand cmd = new SqlCommand(@"INSERT INTO ManageStudents(StudentName,StudentEmail,StudentAddress,StudentCity) VALUES(@name,@email,@address,@city)",con);
            cmd.Parameters.AddWithValue("@name", txtStudentName.Text);
            cmd.Parameters.AddWithValue("@email", txtStudentEmail.Text);
            cmd.Parameters.AddWithValue("@address", txtStudentAddress.Text);
            cmd.Parameters.AddWithValue("@city", txtStudentCity.Text);
             SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
     con.Open();
    
            da1.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                Response.Write("Table Updated");
                Response.Redirect("StudentManage.aspx");
    
    
            }
            else
            {
    
                Response.Redirect("Error.aspx");
                //ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }
