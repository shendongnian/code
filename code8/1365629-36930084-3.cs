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
    
    		//We need to mask off the result (otherwise we fail for checking 101 -> 111)
    		//The mask will put 1s in each place the perforator is checking.
    		var perforDigits = (int)Math.Ceiling(Math.Log(perforatorShifted, 2));
    		uint mask = (uint)Math.Pow(2, perforDigits) - 1;
    
    		Console.WriteLine("Ticket:\t" + GetBinary(binaryTicket));
    		Console.WriteLine("Perfor:\t" + GetBinary(perforatorShifted));
    		Console.WriteLine("Mask :\t" + GetBinary(mask));
    		
    		if ((binaryTicket & mask) == perforatorShifted)
    		{
    			Console.WriteLine("Match.");
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
    
    static string GetBinary(uint v)
    {
    	return Convert.ToString(v, 2).PadLeft(32, '0');
    }
