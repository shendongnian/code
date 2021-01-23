    public decimal CalculateNewIncome()
    {
            decimal income;
            // Get the income, tax rate and rate of return.
            income = decimal.Parse(incomeDesiredTextBox.Text);
    
            if (incomePerDayRadioButton.Checked)
            {
                return income / 365;
            }
            else if (incomePerMonthRadioButton.Checked)
            {
                return income / 24; // should be 30 ?
            }
            else if (incomePerWeekRadioButton.Checked)
            {
                return income / 52;
            }
            else if (incomePerYearRadioButton.Checked)
            {
                return income;
            }
    }
