     //Deletes all lines that end with only a CR - this emulates the output as it would be seen cmd
    public static string DeleteCRLines( this string Str) {
    	Str = Str.Replace( "\r\r\n", "\r\n");
    	//Splits at the CRLF. We will end up with 'lines' that are full of CR - the last CR-seperated-line is the one we keep
    	var AllLines = new List<string>( Str.Split( new[] {"\r\n"}, StringSplitOptions.None));
    	for (int i = 0; i < AllLines.Count; i++){
    		var CRLines = AllLines[i].Split('\r');
    		AllLines[i] = CRLines[ CRLines.Count() -1];
    	}
    	return String.Join( Environment.NewLine, AllLines.ToArray());
    }
