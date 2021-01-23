    private static void ReadChar(string sentence, ref int inputType)
	{
		foreach (char test in sentence) {
			if ("|*/+-@#$%^&(),`=".Contains(test)) {
				inputType = 5;
			} // delimiter
			else if (Char.IsDigit(test)) {
				inputType = 3;
			} // numeric              
			else if (Char.IsWhiteSpace(test)) {
				inputType = 6;
			} // space
			else if (test == ';') {
				inputType = 7;
			} // semicolon          
			else {
				inputType = 1;
			} // end alpha
		}
	}
