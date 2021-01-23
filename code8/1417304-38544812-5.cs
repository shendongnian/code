        repeat:
        Console.WriteLine();
        Console.WriteLine("Which group would you like to edit?  Blank to exit.");
        string Group = Console.ReadLine().ToUpper();
        if(string.IsNullOrEmpty(Group))
            exit;  // this may be return - I forget
        Console.WriteLine("Enter {0}'s new group name if any", Group);
        string newGroup = Console.ReadLine().ToUpper();
        if(string.IsNullOrEmpty(newGroup))
            goto repeat;
        SQLCONN.Open();
        //update Group Name (SAT)
        try
        {
            using (SqlCommand cmd =
            new SqlCommand("UPDATE " + selectedDayTableToEdit + "Table SET SAAT=@NewGroup where SAAT=@SAAT", SQLCONN))
            {
                cmd.Parameters.AddWithValue("@NewGroup", newGroup);
                cmd.Parameters.AddWithValue("@Saat", Group);
                cmd.ExecuteNonQuery();
                Console.WriteLine();
                Console.WriteLine("Database Updated...");
            }
        }
        catch (Exception)
        {
            Console.WriteLine();
            Console.WriteLine("That group already exists");
        }
        finally 
        {
            SQLCONN.Close();
        }
        goto repeat;
