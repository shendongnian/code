    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
       DataTable dt = new DataTable();
       dt = bl.Get_detailsbydate(bo);
       string dates = dt.Rows[0]["EventDate"].ToString();// Confirm if you  EventDate is in a same format to calendar
       if (e.Day.Date == dates)
       { 
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.Red;
       }
    }
