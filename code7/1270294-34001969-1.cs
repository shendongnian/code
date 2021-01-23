    [WebMethod]
    public static string deleteSomething(string deleteSomeID)
    {
        try {
            MySqlDbUtilities db = new MySqlDbUtilities();
            MySqlCommand cmd;
            string sql = "DELETE FROM Targets WHERE targetID = @someID";
            cmd = db.GetCommand(sql);
            cmd.Parameters.AddWithValue("@someID", deleteSomeID);
            cmd.ExecuteNonQuery();
            db.Dispose();
        } 
        catch (Exception e) {
            return e.Message;
        }
        return "1";
    }
