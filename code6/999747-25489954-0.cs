    public static DateTime ToDate(this object value)
        {
         string date = value.ToString("dd.MM.yyyy");
         DateTime dt = Convert.ToDateTime(date); 
         return dt;
        }
