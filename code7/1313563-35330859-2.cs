    public class clsFolding
    {
        //no need for this to be public
        private static string ConStr = ConfigurationManager.ConnectionStrings["FazalConstructions.Properties.Settings.ConnString"].ConnectionString;
            
        public static void createFolding(int id, string name, int qty, string narration, DateTime dt)
        {
             string sql = "INSERT INTO tblFolding(FoldingID, Name,Quantity,Narration,DateTime)VALUES(@id, @name, @qty, @narration,@dt)";
    
             //fyi: a static SqlConnection reference is a VERY BAD IDEA
             // use a new variable in each method call
             using(var con = new SqlConnection(ConStr))
             using(var cmd = new SqlCommand(sql, con))
             {
                 cmd.Parameters.AddWithValue("@id", id);
                 cmd.Parameters.AddWithValue("@name", name);
                 cmd.Parameters.AddWithValue("@qty", qty);
                 cmd.Parameters.AddWithValue("@narration", narration);
                 cmd.Parameters.AddWithValue("@dt", dt);
    
                 con.Open();
                 cmd.ExecuteNonQuery();
             }
        }
    }
