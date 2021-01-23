    private DataTable GetData(string type, string category, string country, string subsidary,string date)
    {
         DateTime? mydate = null;
         DateTime date2;
         bool check = DateTime.TryParse(date, out date2);
         if (check)
         {
             mydate = date2;
         }
    }
