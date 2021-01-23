    void Main()
    {
    	string a1 =@" I(1946) am a string and I have some character and number and some sign like 4412 but I must find 4 sequence numbers in this.";
    	string a2 = @" 2015/10/13 is my birthday.I love this date1234!";	
    	var reg = @"\d{4}";
    	
    	Print(Regex.Matches(a1, reg));
    	Print(Regex.Matches(a2, reg));
    
    }
    
    private void Print(MatchCollection matches)
    {
    	foreach (Match element in matches)
    	{
    		Console.WriteLine(element.Value);
    	}
    }
