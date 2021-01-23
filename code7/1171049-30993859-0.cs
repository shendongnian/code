    try{
          int WeekId = Int32.Parse(Request.QueryString["WeekId"]);
          if (((int)DateTime.Now.DayOfWeek) != WeekId)
           {
                    Response.Write("<h4>Sorry! Today is NOT the week you selected. Please use Back button of browser and try again!</h4>");
                    Response.End();
           }
            lblToday.Text = DateTime.Now.ToShortDateString();
            lblWeekId.Text = Request.QueryString["WeekId"];
            lblPeriod.Text = Request.QueryString["period"];
            lblSemister.Text = Request.QueryString["Semester"];
       }
    catch(Exception ex)
    {
     //Handle exception here
    }
