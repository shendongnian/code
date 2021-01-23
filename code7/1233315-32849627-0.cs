    DateTime s = Convert.ToDateTime(tbDate.Text);
    TimeSpan ts = new TimeSpan(0, 0, 0);
    s = s.Date + ts;
     
    if (DateTime.Today.AddMonths(-6) == s) //if given date is equal to exactly 6 months past from today (change == to > if date has to be less 6 months)
    {
    lblResult.Text = "true"; //this doesn't work with the entered date above.
    }
    
