    private void mainForm_Shown(object sender, EventArgs e)
    {
        PopulateMonthsAndYears();
    }
    
    private void PopulateMonthsAndYears()
    {
        const int BEGIN_YEAR = 1983; // KCMS
        comboBoxMonth.Items.AddRange(PlatypusConstsAndUtils.MonthsFull.ToArray<object>());
        comboBoxMonth.SelectedIndex = PlatypusConstsAndUtils.GetIndexForPreviousMonth();
    
        comboBoxYear.DataSource = Enumerable.Range(BEGIN_YEAR, DateTime.Now.Year - BEGIN_YEAR + 1).ToList();
        comboBoxYear.SelectedIndex = comboBoxYear.Items.IndexOf(DateTime.Now.Year);
    
        // However, if it is January (and thus the month is set to December), set the year to previous also
        if (comboBoxMonth.SelectedIndex == 11) // December
        {
            comboBoxYear.SelectedIndex = comboBoxYear.Items.IndexOf(DateTime.Now.Year - 1);
        }
    }
