    public void SetupTimers()
    {
        DB db = new DB();
        DataTable dtLinks = new DataTable();
        dtLinks = db.GetDataTable(String.Format("SELECT Id, Name, URL, Time, Active FROM Shed WHERE Active = 1"));
        foreach (DataRow row in dtLinks.Rows)
        {
            SetupShed(1, "WILLBURL", "WILLBENAME");
        }
    }
    static void SetupShed(double ms, String url, String name)
    {
            System.Timers.Timer timer = new System.Timers.Timer(ms);
            timer.AutoReset = true;
            timer.Elapsed += Ping;
            timer.Start();
    }
    static void Ping(object sender, System.Timers.ElapsedEventArgs e)
    {
        //do you pinging
    }
