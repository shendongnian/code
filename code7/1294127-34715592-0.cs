	var input = "P@ssw0rd";
	
	var hasNumber = new Regex(@"[0-9]+");
	var hasUpperChar = new Regex(@"[A-Z]+");
	var hasMinimum8Chars = new Regex(@".{8,}");
	
	var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
	Console.WriteLine(isValidated);
