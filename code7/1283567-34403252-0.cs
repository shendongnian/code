    protected void gvMasterProjects_RowDataBound(object sender, GridViewRowEventArgs  e)
    {
        //This if/else statement overrides the hard coded date headers in the timeEntry aspx files since the days were hardcoded in.
        //Populates the cells w/ the data from one of two arrays depending if the user is A or B.
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "HeaderStyle";
            var bufferDay = 0; // Starts on sunday.
            if (isUserB)
            {
                bufferDay = 1; // Starts on Monday.
            }
            for (int i = 9; i < 23; i++)
            {
                e.Row.Cells[i].Font.Size = 10;
                var dayOfWeek = _displayDate.AddDays(i - 9 + bufferDay);
                e.Row.Cells[i].Text = dayOfWeek.ToString("ddd") + "\n" + " " + dayOfWeek.ToString("MM/dd") + " ";
            }        
        }
    }
