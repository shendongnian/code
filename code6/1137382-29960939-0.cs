    var mapToArabic = 
      new Dictionary<char, char>{ 
  		{'۰', '0'}, {'۱', '1'}, {'۲', '2'}, 
		{'۳', '3'}, {'۴', '4'}, {'۵', '5'}, 
		{'۶', '6'}, {'۷', '7'}, {'۸', '8'}, {'۹', '9'}};
    var p = new System.Globalization.PersianCalendar(); 
    var start = "۱۳۹۴/۰۲/۲۰";
    string[] persian = start.Split('/');    
    var arabic = persian
                    .Select(persianWord => 
                        new string(persianWord
                                    .Select(persianChar => mapToArabic[persianChar])
                                    .ToArray()))
                    .ToList();
    DateTime dt = new DateTime(int.Parse(arabic[0]),
                               int.Parse(arabic[1]),
                               int.Parse(arabic[2]),
                               new System.Globalization.HijriCalendar());
    var pc = new System.Globalization.PersianCalendar();
    var result = pc.ToDateTime(dt.Year, dt.Month, dt.Day, 
                                dt.Hour, dt.Minute, 0, 0); 
