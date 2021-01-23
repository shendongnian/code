    public void addToDB(List<Vo2phase> phases)
    {
        try
        {
            //prepare for query
            var cmd = MySQL.readyQuery();
            //insert testdata to Vo2test
            cmd.CommandText = "INSERT INTO vo2phases_tb (Vo2_TestID, Phase, Time, Intensity, RER, Borgscale, Pulse) VALUES (@Vo2testid, @phase, @time, @intensity, @rer, @borgscale, @pulse);";
            cmd.Prepare();
            foreach (Vo2phase phase in phases)
            {
                cmd.Parameters.AddWithValue("@vo2testid", VO2TestID);
                cmd.Parameters.AddWithValue("@phase", Phase);
                string TimeString = "00:" + Convert.ToString(Time.TimeOfDay.Hours) + ":" + Convert.ToString(Time.TimeOfDay.Minutes);
                cmd.Parameters.AddWithValue("@time", TimeString);
                cmd.Parameters.AddWithValue("@intensity", Intensity);
                cmd.Parameters.AddWithValue("@rer", RER);
                cmd.Parameters.AddWithValue("@borgscale", Borgscale);
                cmd.Parameters.AddWithValue("@pulse", Pulse);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
