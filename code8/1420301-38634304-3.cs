    public MainWindow()
    {
        InitializeComponent();
    }
    private void dpkDOB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {
        var ageInYears = GetDifferenceInYears(dpkDOB.SelectedDate.Value, DateTime.Today);
        if (ageInYears < 18)
        {
            MessageBox.Show("Under age");
        }
    }
    int GetDifferenceInYears(DateTime startDate, DateTime endDate)
    {
        return (endDate.Year - startDate.Year - 1) +
            (((endDate.Month > startDate.Month) ||
            ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
    }
