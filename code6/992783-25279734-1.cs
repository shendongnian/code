    public ActionResult Students()
    {
        String connectionString = "<THE CONNECTION STRING HERE>";
        String sql = "SELECT * FROM students";
        SqlCommand cmd = new SqlCommand(sql, conn);
    
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            var model = new List<Student>();
            while(rdr.Read())
            {
                var student = new Student();
                student.FirstName = rdr["FirstName"];
                student.LastName = rdr["LastName"];
                student.Class = rdr["Class"];
                ....
    
                model.Add(student);
            }
    
        }
    
        return View(model);
    }
