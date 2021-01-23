    // This one gets the index from the list of matches
    private static string LookupReplace(string text, List<string> newList)
 	{
		var result = "~" + newList.IndexOf(text).ToString() + "~";
		return result;
 	}
 	
    // This one just increments a global counter
  	private static string NumberedReplace()
 	{
		i++;
		return "~" + i.ToString() + "~";
 	}
 	
    public static int i = -1;
    
    public static void Main()
    {   
        string text = "iif(instr(|Wellington, New Zealand|,|,|)>0,|Wellington, New Zealand|,|Wellington, New Zealand| & |, | & |New Zealand|) & | to | & iif(instr(|Jeddah, Saudi Arabia|,|,|)>0,|Jeddah, Saudi Arabia|,|Jeddah, Saudi Arabia| & |, | & |Saudi Arabia|) & iif(|Jeddah, Saudi Arabia|=||,||,| via | & |Jeddah, Saudi Arabia|)";
        var re = new Regex(@"\|.*?\|");
        var newList = re.Matches(text)
            			.OfType<Match>()
            			.Select(m => m.Value)
    					.ToList();
        // First replace with index
        string result = re.Replace(text, x => LookupReplace(x.Value, newList));
        Console.WriteLine(result);
        
        // Second replace with counter
        result = re.Replace(text, x => NumberedReplace());
        Console.WriteLine(result);
    }
