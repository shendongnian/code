    string NewTextValue = "str";
    int characterLimit = 5;
	string regxForAlpha = "^[a-zA-Z \n]{0,"+characterLimit.ToString()+"}$";
	if(!string.IsNullOrEmpty(NewTextValue))
		if (!Regex.IsMatch( NewTextValue, regxForAlpha)){
			Console.WriteLine("No match");
		}
		else
		{
			Console.WriteLine("Match");
		}
