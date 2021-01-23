    DateTime endDate = new DateTime(DateTime.Today.Year + 1, 4, 1).AddDays(-1);
    if (Convert.ToDateTime(empHiredDate).Month > 4)
    {
        finMonth = Convert.ToDateTime(empHiredDate).Month - 4;
        finMonth = 12 - finMonth;
        avail =Convert.ToString(finMonth * 1.25);
    }
    else if (Convert.ToDateTime(empHiredDate).Month < 3)
    {
        finMonth = Convert.ToDateTime(empHiredDate).Month + 8;
        finMonth = 12 - finMonth;
        avail = Convert.ToString(finMonth * 1.25);
    }
    else if (Convert.ToDateTime(empHiredDate).Month == 4)
    {
        avail = Convert.ToString(12 * 1.25);
    }
    else if (Convert.ToDateTime(empHiredDate).Month == 3)
    {
        avail = Convert.ToString(1 * 1.25);
    }
