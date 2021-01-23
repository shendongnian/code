    lblReadDate.Text = compareDate(programming1, "Programming Assignment 1");
    lblReadDate2.Text = compareDate(programming2, "Programming Assignment 2");
    
    // common method
    public string compareDate(DateTime dateToCompare, string name) {
    	if (DateTime.Now >= dateToCompare)
    		return "Due date for " + name + " has been reached (" + dateToCompare.ToShortDateString() + ").";
    	return "Days remaining until " + name + " deadline: " + dateToCompare.ToString("0");
    }
