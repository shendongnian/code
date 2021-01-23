        string j = "Data Source=FUJITSU-PC\\SQLEXPRESS;Initial Catalog=attendance_system;Integrated Security=True";
        using (SqlConnection cn = new SqlConnection(j))
        {
            SqlCommand cmd = new SqlCommand("select dbo.faculty_status.username from dbo.faculty_status", cn);
            cn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Console.WriteLine(reader["username"]);
                }
            }
        }
