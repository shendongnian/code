    public DateTime ConvertFromObjectToDate(object dbdate){
        if(dbdate is null || !(dbdate is DateTime))return DateTime.MinValue;
         var result =   ConvertFromUTCDate(Convert.ToDateTime (dbdate),UserTimeZone); 
         return result; 
    }
