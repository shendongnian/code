    private List<StudentClass> getStudentGrades(List<StudentClass> studentList)
    {
            string studentListParam = "";
            foreach(StudentClass student in studentlist)
            {
               // blah blah stuff to only add comma if not first element
               studentListParam = studentListParam + ", '" + student.StudentName + "';
            }
    
            string sqlcommand = @"
    SELECT StudentName, StudentGrades
      FROM Students
     WHERE StudentName in (" + studentlist + ")";
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sqlcommand, conn))
            {
                cmd.Parameters.AddWithValue("@StudentName", studentList[i].StudentName);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
    
                while (reader.Reader())
                {
                    StudentClass student = studentList.Where(s => s.StudentName == string.Parse(reader["StudentName"]);
                    student.StudentGrades = int.Parse(reader["StudentGrades"].ToString());
                }
            }
        }
    
        return studentList;
    }
    
    public class StudentClass
    {
        public string StudentName {get; set; }
        public int StudentGrades {get; set; }
    }
