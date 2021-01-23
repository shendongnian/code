    int year = 2015;
    int month = 10;
    DateTime dateToCheck = DateTime.Today.Date;
    DateTime startDate = new DateTime(year, month, 1);
    DateTime endDate = startDate.AddMonths(1);
    foreach (SPListItem item in collection)
    {
        if (startDate <= dateToCheck && dateToCheck < endDate)
        {
             ListBox1.Items.Add(item["EventTitle"].ToString());
        } 
    }
