    public override void getJobsFromSource()
    {
        string url = @"https://data.usajobs.gov/api/jobs?Country=United%20States&NumberOfJobs=1&Page=1";
        
        using(WebClient client = new WebClient()) {
            string json = client.DownloadString(url);
            DataTable dt = new DataTable();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(json);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
           
        }            
    }
