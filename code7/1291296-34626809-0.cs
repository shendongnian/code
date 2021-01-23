    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
            if (e.Day.IsSelected == true)
            {
                list.Add(e.Day.Date);
            }
            Session["SelectedDates"] = list;
    }
    
    
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    Calendar1.SelectedDates.Add(dt);
                }
                list.Clear();
            }
    }
