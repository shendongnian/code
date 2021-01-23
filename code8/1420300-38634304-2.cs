    public MainWindow()
    {
        InitializeComponent();
    }
    private void dpkDOB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {
        var ageInYears = GetYears(dpkDOB.SelectedDate.Value, DateTime.Today);
        if (ageInYears < 18)
        {
            MessageBox.Show("Under age");
        }
    }
    int GetYears(DateTime start, DateTime end)
    {
        return (end.Year - start.Year - 1) +
            (((end.Month > start.Month) ||
            ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
    }
