    public DataTable GetAllCourseName()
    {
       SqlConnection objsqlconn = new SqlConnection(conn);
       objsqlconn.Open();
       SqlDataAdapter da = new SqlDataAdapter("select cos_ID, cos_name from course_details", objsqlconn); 
       DataSet ds = new DataSet(); 
       da.Fill(ds, "course_details"); 
       return ds.Tables["course_details"];
    }
