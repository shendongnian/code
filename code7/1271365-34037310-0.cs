     public static List<Student> GetData()
        {
            List<Student> lstStudent = new List<Student>();
            using (SqlConnection con = new SqlConnection(@"Data Source=PALLAVI-PC\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;MultipleActiveResultSets=True;"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Tbl_Students;", con))
                {
                    cmd.CommandType = CommandType.Text;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();                   
                    while(reader.Read())
                    {
                        Student student =new Student();
                        student.Roll_Number = Convert.ToInt32(reader.GetValue(0));
                        student.FirstName = reader.GetValue(1).ToString();
                        student.LastName = reader.GetValue(2).ToString();
                        student.Class = Convert.ToInt32(reader.GetValue(3));
                        student.Gender = reader.GetValue(4).ToString();
                        lstStudent.Add(student);
                    }                   
                    
                }
            }
            return lstStudent;
        }
