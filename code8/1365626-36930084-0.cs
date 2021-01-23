    static void Main(string[] args)
    {
    	//this is the number I'm searching for a match in
    	uint binaryTicket = 469;
    	//This is the pattern I'm trying to match (101)
    	uint binaryPerforator = 5;
    	
    	var numBinaryDigits = Math.Ceiling(Math.Log(binaryTicket, 2));
    	for (var i = 0; i < numBinaryDigits; i++)
    	{
    		var perforatorShifted = binaryPerforator << i;
    		if ((binaryTicket & perforatorShifted) == perforatorShifted)
    		{
    			//Imagine we have the case:
    			
    			//Ticket:
    			//111010101
    			//Perforator:
    			//000000101
    			
    			//Is a match. What binary operation can we do to 0-out the final 101?
    			//We need to AND it with 
    			//111111010
    			
    			//To get that value, we need to invert the perforatorShifted
    			//000000101
    			//XOR
    			//111111111
    			//EQUALS
    			//111111010
    			
    			//Which would yield:
    			//111010101
    			//AND
    			//111110000
    			//Equals
    			//111010000
    			
    			var flipped = perforatorShifted ^ ((uint)0xFFFFFFFF);
    			binaryTicket = binaryTicket & flipped;
    		}
    	}
    
    	string binaryTicket01 = Convert.ToString(binaryTicket, 2);
    	Console.WriteLine(binaryTicket01);
    }
