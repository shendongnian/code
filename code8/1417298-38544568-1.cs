       new SqlCommand("UPDATE " + selectedDayTableToEdit + "Table SET SAAT=@SAAT where SAAT=@GroupName", SQLCONN))
                {
                    cmd.Parameters.AddWithValue("@Saat", newGroup);
                    cmd.Parameters.AddWithValue("@GroupName", Group);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Database Updated...");
                }
