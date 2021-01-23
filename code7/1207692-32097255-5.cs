         public static DateTime? ToDateTimeCheck2(this string valor)
    {
           var isDate = true;
            DateTime dt;
            isDate  = DateTime.TryParse(valor, out dt);
            if (isDate)
                return dt;
            else
            return null;
       
    }
