    public void AddIncoming_Click(object sender, EventArgs e)
    {
        if (frequencyIncoming.SelectedValue == "Weekly")
        {
            DateTime weekly = DateTime.Now;
            TimeSpan timeToWait = new TimeSpan(0, 0, 0, 5); // days, hours, minutes, seconds
            bool keepLooping = true;
            while (keepLooping)
            {
                if (DateTime.Now.Subtract(weekly) < timeToWait)
                {
                    //sleep 1 second while waiting so cpu doesn't spin at maximum
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    // this code will run every ~timeToWait
                    Console.WriteLine($"{DateTime.Now.Subtract(weekly)} seconds have elapsed.");
                    weekly = DateTime.Now;
                }
            }
        }
        SqlCommand cmd = new SqlCommand("insert into Incomings (AspNetUsersId,IncType,IncDate,IncCost,IncFrequency) values (@AspNetUsersId, @IncType, @IncDate, @IncCost, @IncFrequency)");
        cmd.Parameters.AddWithValue("@AspNetUsersId", userId);
        cmd.Parameters.AddWithValue("@IncType", typeIncoming.Text);
        cmd.Parameters.AddWithValue("@IncDate", lblCalendar.Text);
        cmd.Parameters.AddWithValue("@IncCost", costIncoming.Text);
        cmd.Parameters.AddWithValue("@IncFrequency", frequencyIncoming.Text);
        loadDatabase(cmd);
        Response.Redirect(Request.Url.AbsoluteUri);
    }
