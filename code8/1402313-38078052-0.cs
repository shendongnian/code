    DateTime start;
    
    void StartTimer()
    {
        start = DateTime.Now;
    }
    
    void UpdateDisplay()
    {
        var timespan = DateTime.Now.Subtract(start);
        displaycounter.Text = "Elapsed Time in " + statusName + " " + timespan.ToString(@"mm\:ss"));
    }
