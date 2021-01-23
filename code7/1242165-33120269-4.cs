    public int[] GetLetters(String userName)
    {    
    	int[] threeLetters = new int[3];
    
        // some special block 1
        {
        	char firstLetter = userName1[0];    
            threeLetters[0] = firstLetter;
        }
    
        // some special block 2
        {
        	char firstLetter = userName2[0];  
            threeLetters[1] = firstLetter ;          	
        }
    	if(userName.Length > 5)
    	{
    		threeLetters = new int[0];
    	}
    
    	return threeLetters;
    }
