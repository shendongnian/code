    int studentNo = int.Parse(textBox1.Text);
    string sql = "SELECT Name FROM StudentInfo where StudentNo=@student_no";
    using (var command = new SqlCommand(conn, sql))
    {
        command.Parameters.Add("@student_no", SqlDbType.Int).Value = studentNo;
        // Execute the command as normal
    }
