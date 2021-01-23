    if(c.Length > 5)								// Checking if digit of product is greater than 5
    		{
    			int[] n = new int[c.Length];
    			StringBuilder sb = new StringBuilder();
    			
    			if((c[0] == c[c.Length-1]) && 				// Comparing first and second half of product
    				(c[1] == c[c.Length-2]) && 
    				(c[2] == c[c.Length-3])) 
    			{
    				for(int l = 0; l < c.Length; l++)		// Converting each value in the char array to a stringbuilder
    				{
    					sb.Append(Convert.ToInt32(new string(c[l], 1)));
    				}
    				m[q] = Int32.Parse(sb.ToString());		// Converting stringbuilder into string and then into a long
    				q++;
    			}
    		}
