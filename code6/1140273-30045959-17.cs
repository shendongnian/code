    string word = "hello";		
    for(int i=0; i<word.Length-2; i++)
    	for(int j=i+1; j< word.Length-1; j++)		   
           for(int k=j+1; k < word.Length; k++)
    	   {
             string sub = string.Format("{0}{1}{2}",word[i], word[j], word[k]);
    	     Console.Write(string.Format("{0}{1}{2}",sub[0], sub[1], sub[2]));
 			 Console.Write(string.Format("\t{0}{1}{2}",sub[2], sub[1], sub[0]));
			 Console.Write(string.Format("\t{0}{1}{2}",sub[1], sub[0],sub[2]));
 			 Console.Write(string.Format("\t{0}{1}{2}",sub[0], sub[2], sub[1]));		
			 Console.Write(string.Format("\t{0}{1}{2}",sub[1], sub[2], sub[0]));		
			 Console.WriteLine(string.Format("\t{0}{1}{2}",sub[2], sub[0], sub[1]));		
    		}
