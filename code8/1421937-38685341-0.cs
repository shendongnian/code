     Series series = new Series("Series1", ViewType.Spline);
    
                chartControlMIVBaseDateTime.Series.Add(series);
    
                // Generate a data table and bind the series to it.
                series.DataSource = _materialIssueVoucherRepository.ViewImivBasedOnDates().ToList();
    
                // Specify data members to bind the series.
                series.ArgumentScaleType = ScaleType.DateTime;
                series.ArgumentDataMember = "DateTime";
                series.ValueScaleType = ScaleType.Numerical;
                series.ValueDataMembers.AddRange(new string[] { "Count" });
