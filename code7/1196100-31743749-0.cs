    public static DateTime ToDateTime(this object Value,string Format)
            {
                DateTime dateTime;            
                DateTime.TryParseExact(Value.ToString(), Format, null, DateTimeStyles.None, out dateTime);
                return dateTime;
            }
    
    Sample:
    
    int Intdates = 31072015;
    DateTime Date = Intdates.ToDateTime("DDMMyyyy")
