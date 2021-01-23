    public class Student
    {
        public int StudentID { get; set; }
        public bool CurrentlyEnrolled { get; set; }
        public string Name { get; set; }
        public static Student LoadByID(int ID)
        {
            DataTable results = DAL.ExecuteSQL("Select * from Students WHERE StudentID = @StudentID", new SqlParameter("@StudentID", ID));
            if (results.Rows.Count == 1)
            {
                return FillFromRow(results.Rows[0]);
            }
            else
            {
                throw new DataException("Could not find exactly one record with the specified ID.");
            }
        }
        private static Student FillFromRow(DataRow row)
        {
            Student bob = new Student();
            bob.CurrentlyEnrolled = (bool)row["CurrentlyEnrolled"];
            bob.Name = (string)row["Name"];
            bob.StudentID = (int)row["StudentID"];
            return bob;
        }
    }
    public static class DAL
    {
        private const string ConnectionString = "SomeConnectionString"; //Should really be stored in configuration files.
        public static DataTable ExecuteSQL(string SQL, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SQL))
                {
                    command.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        return result;
                    }
                }
            }
        }
    }
