    public static int createFolding(int id, string name, int qty, string narration, DateTime dt)
        {
            try
            {
                con = new SqlConnection(ConStr);
                con.Open();
                cmd = new SqlCommand("INSERT INTO tblFolding(FoldingID, Name,Quantity,Narration,DateTime)VALUES(@id, @name, @qty, @narration,@dt)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@narration", narration);
                cmd.Parameters.AddWithValue("@dt", dt);
                cmd.ExecuteNonQuery();
                return new TClass { Result = 1 };
            }
            catch (Exception ex)
            {
                return new TClass { Result = o, Error = ex };
            }
