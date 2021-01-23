    public int solution(int[] A)
    {
    	int flag = 1;
    
    	A = A.OrderBy(x => x).ToArray();
    
    	for (int i = 0; i < A.Length; i++)
    	{
    		if (A[i] <= 0)
    			continue;
    		else if (A[i] == flag)
    		{
    			flag++;
    		}
    
    	}
    
    	return flag;
    }
