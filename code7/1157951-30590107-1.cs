    Dictionary<string,string> days = new Dictionary<string,string>();
    days.Add("Monday", "MON");
    days.Add("Tuesday", "TUE");
    days.Add("Wednesday", "WED");
    days.Add("Thuesday", "THU");
    days.Add("Friday", "FRI");
    days.Add("Saturday", "SAT");
    days.Add("Sunday", "SUN");
    //Edit
    MessageBox.Show(days[DateTime.Now.DayOfWeek.ToString()] + DateTime.Now.ToString( " MM/dd"));
