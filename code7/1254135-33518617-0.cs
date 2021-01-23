    public void Test()
        {
            int month = 11;
            int year = 2015;
            int days = DateTime.DaysInMonth(year, month); //This will give us days = 30
            for (int i = 1; i < days; i++)
            {
                string dayteTime = new DateTime(year, month, i).ToString("D");
                //This will create the following Output:
                //Sunday, 1. November 2015
                //Monday, 2. November 2015
                //.... this can be added to a list or how ever you need the days.
            }
        }
