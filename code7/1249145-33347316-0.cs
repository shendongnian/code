    string lastClickDateValue = GetMonthClickedFromDatabase(); //Connect to database and get the value within this method
    DateTime lastClickDate = Convert.ToDateTime(lastClickDateValue);
    
    if(lastClickDate.Month == DateTime.Now.Month)
    {
         btnMonth.Enabled = false; //Button ID you want to disable
    }
