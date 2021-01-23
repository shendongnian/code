        DateTime WeekBeginDate;
    
         if(this.Page.Request["WeekBeginDate"] != null)
         {                  
           WeekBeginDate = DateTime.Parse(this.Page.Request["WeekBeginDate"].ToString());
           
           Chart1.Titles[0].Text = WeekBeginDate.AddDays(6).ToString();
    
         }
