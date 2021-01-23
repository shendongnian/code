    enum EnumSet {item1=1,item2=2,item4,item300=300};
    	public static void Main()
    	{
    		
    		string enumset=Console.ReadLine();
    		int e= int.Parse(enumset);
    		
    		switch(e) {
    			case (int)EnumSet.item1:
    			{   
    				Console.WriteLine("Hello!");
    				break;
    			}
    
    		}
    			
    	}
