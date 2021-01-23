        [HttpPut]
        [ActionName("UpdateStudent")]
        public void UpdateStudent(int id, [FromBody]Tbl_Students student)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=PALLAVI-PC\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;MultipleActiveResultSets=True;";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update Tbl_Students set Class=" + student.Class + " where Roll_Number=" + id + ";";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowUpdated = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
