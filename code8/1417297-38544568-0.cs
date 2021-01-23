       new SqlCommand("UPDATE " + selectedDayTableToEdit + "Table SET SAAT=@SAAT where SAAT=@" + Group, SQLCONN))
                {
                    cmd.Parameters.AddWithValue("@Saat", newGroup);
                    cmd.Parameters.AddWithValue("@" + Group, Group);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Database Updated...");
                }
