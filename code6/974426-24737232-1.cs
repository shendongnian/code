    private void Form1_Load(object sender, EventArgs e)
    {
        GetWeekHelper(DateTime.Parse("2014-01-03 11:00:00"));  //2
        GetWeekHelper(DateTime.Parse("2015-01-02 11:00:00"));  //2
        GetWeekHelper(DateTime.Parse("2016-01-01 11:00:00"));  //1
        GetWeekHelper(DateTime.Parse("2016-01-01 9:00:00"));   //0
    }
    private void GetWeekHelper(DateTime date)
    {
        Console.WriteLine(String.Format("{0} - {1}", date.ToString(), GetWeek(date)));
    }
