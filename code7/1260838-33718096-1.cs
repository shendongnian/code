    string ConnStr = Connection();
    string query = "Delete from Anouncement where AnnouncementID=@i";
    using (SqlConnection conn = new SqlConnection(ConnStr))
    {
         using (SqlCommand cmd = new SqlCommand(query, conn))
         {
             try
                {
                    SqlParameter p1 = new SqlParameter("i", bo.A_ID);
                    cmd.Parameters.Add(p1);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result > 0)
                    {
                        Console.WriteLine 
                        ("\n\n\t============================================");
                        Console.WriteLine("\tAnnouncement Deleted");
                        Console.WriteLine 
                        ("\t============================================\n\n");
                        }
                }
                catch (Exception ex)
                {
                   //Do your exception handling work
                }
          }
    }
