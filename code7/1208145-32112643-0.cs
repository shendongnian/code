    List<string> result = new List<string>();
    for(int i =0; i<str.Length; i++)
    {
    	foreach (string word in stop_word)
    	{
    		str[i] = str[i].ToLower().Replace(word, "").Trim();
    	}
        result.Add(str[i]);
    }
    			
    foreach(string r in result)
    {
        //this is to printout the result
    	Console.WriteLine(r); 
    }
