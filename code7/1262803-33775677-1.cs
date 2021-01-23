<!-- -->    
    	private static void WriteOffset(int offset, int width, string text)
    	{		  
    		string pad = new String(' ', offset);	
    	
    		int i = 0;
    		while (i < text.Length)
    		{ 
                // print text by 1 symbol 
    			Console.Write(text[i]);
    			i++;      
    			if (i%width == 0)
    			{
                    // when line end reached, go to next
    				Console.WriteLine();
                    // make offset for new line
    				Console.Write(pad);
    			}  
    		}
    	}	
    }
