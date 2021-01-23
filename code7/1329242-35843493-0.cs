    for (int i = 0; i < Products.Rows.Count; i++)
    {
        DataGridViewRow dr = Products.Rows[i];
        if (dr.Selected == true)
        {
            Products.Rows.RemoveAt(i);
            // CODE ADDED
            MySqlCommand cmd = sql.CreateCommand(); // creates the MySQL object needed for queries (I think there's another way also, but I use this)
            cmd.CommandText = "DELETE FROM table WHERE id = 1"; // sets the query
            try
            {
                cmd.ExecuteNonQuery(); // executes the query
            }
            catch( MySqlException e )
            {
                sql.Close();
                Console.WriteLine( e.Message );
            }
            sql.Close();
            // CODE ADDED
        }
    }
