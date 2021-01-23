    string mask   = "ddMMyyyy";
    string egFile = "Finance_01052016.csv";
    if (egFile.Length >= mask.Length) {
    	string possibleDate = Path.GetFileNameWithoutExtension(egFile).Substring(mask.Length);
    	
    	DateTime dateTime;
    	if (DateTime.TryParseExact(possibleDate, mask, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime)) {
    		Console.Write("{0} is {1}", egFile, dateTime);
    	}
    }
