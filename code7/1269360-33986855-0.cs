    [WebMethod]
      public Student[] getall()
     {
        List<Student> studentList=new List<Student>();
        SqlConnection conn;
        conn = Class1.ConnectionManager.GetConnection();
        conn.Open();
    
        SqlCommand newCmd = conn.CreateCommand();
    
        newCmd.CommandType = CommandType.Text;
        newCmd.CommandText = "select * from dbo.tblUser";
        SqlDataReader sdr = newCmd.ExecuteReader();
        
        while(sdr.Read()){
            Student student= new Student();
            student.id = Int32.Parse(sdr["Id"].ToString());
            student.name = sdr["name"].ToString();
            student.grade = sdr["grade"].ToString();
            studentList.Add(student);
        }
        conn.Close();
        sdr.Close();
        return studentList.ToArray();
     }
