    public List<CourseDetailsClass> GetAllCourseName()
    {
       SqlConnection objsqlconn = new SqlConnection(conn);
       objsqlconn.Open();
       SqlDataAdapter da = new SqlDataAdapter("select cos_ID, cos_name from course_details", objsqlconn); 
       DataSet ds = new DataSet(); 
       da.Fill(ds, "course_details"); 
    
       List<CourseDetailsClass> courseName = new List<CourseDetailsClass>();
    
       foreach(DataRow row in ds.Tables["course_details"].Rows)
       {
            courseName.Add(new CourseDetailsClass
            {
                cos_ID = row["cos_ID"].ToString(),
                cos_name = row["cos_name"].ToString()
            });    		
        }
         return courseName;
    }
