    while(true)
    {
        System.Threading.Thread.Sleep(1000);
        string pos = "unknown";
        string dur = "unknown";
    
        try 
        {
            pos = mediaplayer1.Position.Ticks.ToString();
            dur = mediaplayer1.NaturalDurataion.TimeSpan.Ticks.ToString()
            if (pos == dur)
            {
                // MediaEnded!!!!!
                pos = "0";
                dur = "0";
            }
            catch {}
        }
    }
