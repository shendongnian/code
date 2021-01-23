    using System;
    using System.Text.RegularExpressions;
    	string input = "same X same Y same Z";
    
    	var myRegex = new Regex("same(\\s*)(?:(X)|(Y)|(Z))", RegexOptions.IgnoreCase);
    
    	string output = myRegex.Replace(input, Callback);
    	
    	Console.WriteLine(output);
    
    static string Callback(Match match) {
    	
    	string toReturn = "";
    	
    	if (match.Groups[2].Value != "") {
    		
    		toReturn = "abc";
    		
    	} else if (match.Groups[3].Value != "") {
    		
    		toReturn = "def";
    		
    	} else if (match.Groups[4].Value != "") {
    		
    		toReturn = "ghi";
    	}
    	
    	return toReturn + match.Groups[1].Value + match.Groups[2].Value + 
    		match.Groups[3].Value + match.Groups[4].Value;
    }
