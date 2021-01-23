    public static string ToPigLatin(string word)
    {
        string result = string.Empty;
    	string pigSuffixVowelFirst = "yay";
    	string pigSuffixConstanantsFirst = "ay";
    
    	string vowels = "aeiouAEIOU";
    
    	if(vowels.Contains(word.First()))
    	{
    		result = word + pigSuffixVowelFirst;
    	}
    	else
    	{
    		int count = 0;
    		string end = string.Empty;
    		foreach(char c in word)
    		{
    			if (!vowels.Contains(c))
    			{
    				end += c;
    				count++;
    			}
    			else
    			{
    				break;
    			}
    		}
    
    		result = word.Substring(count) + end + pigSuffixConstanantsFirst;
    	}
    	return result;
    }
