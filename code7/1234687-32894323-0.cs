    public static void mudarspawn1(GtaPlayer player, float x, float y, float z)
        {
            if (x == 0 || y == 0 || z == 0)
            {
            }
            else
            {
                string sql = "update spawnposition set spawn_1x = '" + x + "', spawn_1y = '" + y + "', spawn_1z = '" + z + "' where id ='1'";
                try
                {
                    MySqlConnection conn = new MySqlConnection(cs);
                    conn.Open();
                    MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                    cmd1.ExecuteNonQuery();
                    player.SendClientMessage(Color.DarkOrange, "Foi adicionado o spawn 1");
                }
                catch (MySqlException e)
                {
                }
            }
