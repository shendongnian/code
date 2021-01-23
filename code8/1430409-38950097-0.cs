    private async void adjustStatsButton_Click(object sender, EventArgs e)
        {
                await ReadWrite.AdjustStats(winnerInput.Text, loserInput.Text);
                winnerInput.Text = "";
                loserInput.Text = "";
                Refresh(leaderboardBox);
        }
        public class ReadWrite
            {
                public static Task AdjustStats(string winner, string loser)
                {
        return Task.Run(() => 
        {
           SQLiteConnection dbConnection = new SQLiteConnection("Data Source = Leaderboards.sqlite; Version = 3");
        
        
                string sql = "SELECT * FROM leaderboard WHERE name='" + winner + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                dbConnection.Open();
                SQLiteDataReader reader = await command.ExecuteReaderAsync();
        
        
                double wrating = Convert.ToDouble(reader["rating"]);
                int wmatches = Convert.ToInt32(reader["matches"]);
                int wwins = Convert.ToInt32(reader["wins"]);
        
                sql = "SELECT * FROM leaderboard WHERE name='" + loser + "'";
                command = new SQLiteCommand(sql, dbConnection);
                reader = await command.ExecuteReaderAsync();
        
                double lrating = Convert.ToDouble(reader["rating"]);
                int lmatches = Convert.ToInt32(reader["matches"]);
                int lwins = Convert.ToInt32(reader["wins"]);
                int llosses = Convert.ToInt32(reader["losses"]);
        
                double RC = (1 - ((wrating - lrating) / 200)) * 8;
                if (RC < 0) RC *= -1;
                if (RC < 4) RC = 4;
                else if (RC > 12) RC = 12;
        
                wmatches++;
                wwins++;
                lmatches++;
                llosses++;
                wrating += RC;
                if (wrating < 0) wrating = 0;
                lrating -= RC;
                if (lrating < 0) lrating = 0;
                double wwinrate = Convert.ToDouble(wwins) / wmatches;
                double lwinrate = Convert.ToDouble(lwins) / lmatches;
        
                sql = "UPDATE leaderboard SET rating=" + wrating + ", matches=" + wmatches + ", wins=" + wwins + ", winrate=" + wwinrate + " WHERE name='" + winner + "'";
                command = new SQLiteCommand(sql, dbConnection);
                await command.ExecuteNonQueryAsync();
        
                sql = "UPDATE leaderboard SET rating=" + lrating + ", matches=" + lmatches + ", losses=" + llosses + ", winrate=" + lwinrate + " WHERE name='" + loser + "'";
                command = new SQLiteCommand(sql, dbConnection);
                await command.ExecuteNonQueryAsync();
                dbConnection.Close();
                }
    });
                    
            }
