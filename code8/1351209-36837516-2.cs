        public List<Student> loaddataFull()
        {
            List<Student> student = new List<Student>();
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("select * from testing", conn);
            SqlDataReader dr;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    student.Add(new Student()
                    {
                        ID = dr.GetInt32(dr.GetOrdinal("id")),
                        ParentID = dr.GetInt32(dr.GetOrdinal("pid")),
                        Title = dr.GetString(dr.GetOrdinal("title"))
                    });
                }
                dr.Close();
            }
            catch (Exception exp)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
           
            return student;
        }
        
