    private List<StudentClass> getStudentGrades(List<StudentClass> studentList)
    {
        string sqlcommand = "SELECT StudentGrades FROM Students WHERE StudentName=@StudentName";
        var conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand(sqlcommand, conn);
        cmd.Parameters.Add("@StudentName");
        using (conn)
        {
            conn.Open();
            for (int i = 0; i < studentList.Count; i++)
            {
                cmd.Parameters[0].Value= studentList[i].StudentName;
                studentList[i].StudentGrades = (int)cmd.ExecuteScalar();
            }            
        }
        return studentList;
    }
