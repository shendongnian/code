    public List<Teacher> dbConnect(Entity type)
    {
        SQLiteConnection conn = null;
        SQLiteCommand command = null;
        SQLiteDataReader reader = null;
        Teacher result = null; // Can be set to null.
            //    try
            {
                conn = new SQLiteConnection(db.db);
                conn.Open();
                string query;
                // This way, leave the function to build the query.
                if(type == Entity.Teacher) {
                    query = "SELECT * FROM Teacher";
                } else {
                    query = "SELECT * FROM Student";
                }
                command = new SQLiteCommand(query, conn);
                reader = command.ExecuteReader();
            }
            //   catch (Exception ex) { }
            while (reader.Read())
            {
                if(type == Entity.Teacher) {
                    Teacher temp = new Teacher(
                        reader[0].ToString(),    
                        reader[1].ToString(),                              
                        reader[2].ToString(),                              
                        reader[3].ToString(),                              
                        reader[4].ToString(), 
                        reader[5].ToString(),                              
                        reader[6].ToString(),                              
                        reader[7].ToString()                               
                    );
                    result.Items.Add(temp);
                } else {
                    // Add the student.
                }
            }
        conn.Close();
        return result;
    }
