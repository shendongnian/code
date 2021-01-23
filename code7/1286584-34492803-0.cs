    if (Session["timer"] == null)
    {
        Timer Timer1 = new Timer();
        Timer1.Tick += Timer1_Tick;
        Timer1.Interval = 1000;
        Session.Add("timer", Timer1);
    }
