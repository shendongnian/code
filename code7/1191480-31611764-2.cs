    void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {            
        PingOptions Options = new PingOptions(10, true);
        Ping thisPing = new Ping();
        thisPing.PingCompleted += new PingCompletedEventHandler(thisPing_PingCompleted);  
        // send pings asynchronously
        for (int i = 0; i < this.View.Rows.Count; i++)
        {
            var ip = View.Rows[i].Cells[2].Value.ToString();
            thisPing.SendAsync(ip, 100, new byte[0], options, i);                  
        }
    }
    
