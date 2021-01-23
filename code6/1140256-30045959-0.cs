	string word = "hello";
	int [,] arrIndexes = new int[9,3] {{0,1,2}, {0,1,3}, {0,1,4}, {0,2,3}, {0,2,4}, {0,3,4}, {1,2,3}, {1,3,4}, {2,3,4}};
	for(int i=0; i < 9; i++)	
	{	    
	     string sub = "";
	     for(int j=0; j<3; j++)
	     	sub += word[arrIndexes[i,j]];
	     
		 Console.Write(string.Format("{0}{1}{2}",sub[0], sub[1], sub[2]));
		 Console.Write(string.Format("\t{0}{1}{2}",sub[2], sub[1], sub[0]));
		 Console.Write(string.Format("\t{0}{1}{2}",sub[1], sub[0],sub[2]));
		 Console.Write(string.Format("\t{0}{1}{2}",sub[0], sub[2], sub[1]));		
		 Console.WriteLine("");
	}
