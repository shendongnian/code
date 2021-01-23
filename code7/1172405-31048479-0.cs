        protected void ShowCalendar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnSender = (ImageButton)sender;
        String TragetCalendarID = btnSender.UniqueID.Remove(19) + "RefCalendar";
        if (Page.IsPostBack)
        {
            foreach (RepeaterItem rpt in DateRepeater.Items)
            {
                if (rpt.FindControl("RefCalendar").UniqueID == TragetCalendarID)
                {
                    if (rpt.FindControl("RefCalendar").Visible == false)
                    {
                        rpt.FindControl("RefCalendar").Visible = true;
                    }
                    else
                    {
                        rpt.FindControl("RefCalendar").Visible = false;
                    }
                }
            }
        }
    }
