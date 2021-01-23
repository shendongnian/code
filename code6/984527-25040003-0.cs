    protected void Page_Load(object sender, System.EventArgs e)
    {
        string WeekBeginDate = "";
        if(this.Page.Request["WeekBeginDate"] != null)
        {                  
            WeekBeginDate = (string)this.Page.Request["WeekBeginDate"];
            Chart1.Titles[0].Text = WeekBeginDate ;
            
            DateTime actualBeginDate;
            if (DateTime.TryParse(WeekBeginDate, out actualBeginDate))
            {
                DateTime actualEndDate = actualBeginDate.AddDays(6);
                string WeekEndDate = actualEndDate.ToString(); // Pick your favorite string formatting
            }
        }
    }
