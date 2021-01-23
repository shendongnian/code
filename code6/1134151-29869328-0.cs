    const string query = 
        "SELECT PostedBy, PostedDate, COUNT(ThreadId) AS Count " +
        "FROM [Threads] WHERE [TopicId] = @TopicId " +
        "ORDER BY PostedDate DESC " +
        "LIMIT 1";
    var fileToAttach = Server.MapPath("~\\App_Data\\ForumDB.mdf");
    var connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + fileToAttach + ";Integrated Security=True;User Instance=True";
    var topicId = int.Parse(e.Row.Cells[0].Text);
    var postedBy = "";
    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (var cmd = new SqlCommand(query, conn)
        {
            cmd.Parameters.AddWithValue("@TopicId", topicId);
            using (var reader = cmd.ExecuteReader())
            { 
                if (reader.Read())
                {
                    // NOTE: I am assuming you have these cells now!
                    e.Row.Cells[3].Text = reader["Count"].ToString();
                    e.Row.Cells[4].Text = reader["PostedDate"].ToString();
                    postedBy = (string)reader["PostedBy"];
                }
            }
        }
    }
