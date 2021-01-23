    public int[] GetLetters(String userName)
    {    
    	int[] threeLetters = new int[3];
    
    	char firstLetter = userName[0];    
    	char thirdLetter = userName[2];
    	char fifthLetter = userName[4];
    
    	if(userName.Length > 5)
    	{
    		threeLetters = new int[0];
    	}
    
    	return threeLetters;
    }
