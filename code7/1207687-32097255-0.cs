      public static DateTime? ToDateTimeCheck(this string valor)
        {
            DateTime dt;
    
    
            bool isDate = true;
    
    
            try
            {
    
    
                dt = DateTime.Parse(valor);
    
    
            }
    
    
            catch
            {
    
    
                isDate = false;
    
    
            }
    
    
            if (isDate == true)
                return Convert.ToDateTime(valor);
            else
                return null;
    
    
        }
