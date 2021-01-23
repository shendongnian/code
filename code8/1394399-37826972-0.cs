    string dateTimeFormat = "yyyyMMddHHmm";
    string[] FileList = Directory.GetFiles(csvpath, DateTime.Today.ToString("yyyyMMdd") + "*.csv");
    int startHour = 19; // 7 PM
    int endHour = 7; // 7 AM
    DateTime startDT = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
    DateTime.Now.Day - 1, startHour, 0, 0);
    DateTime endDT = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, endHour, 0, 0);
    foreach (var fileName in FileList)
    { 
    	DateTime fileDT = DateTime.Min;
        if(DateTime.TryParseExact(fileName, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyle.None, out fileDT))
        {
    		if(fileDT >= startDT && fileDT <= endDT)
    		{
    			\\file process code.
    		}		
    	}
    }
