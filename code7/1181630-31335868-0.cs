    .Where(x =>{
    string[] strDates = x.DateFieldHere.Split(",");
    DateTime d1,d2;
    if(DateTime.TryParse(strDates[0], out d1) 
    && DateTime.TryParse(strDates[1], out d2))
    { 
      return d1>= parameterHere1 && d2 <= parameterHere2;
    }
    return false; }).SingleorDefault();
