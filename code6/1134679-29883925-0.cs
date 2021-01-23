		var instructionBytes = BitConverter.GetBytes(instruction); 
		var dataBytes = BitConverter.GetBytes(data);
		
		var contentBytes = new byte[] { 
			C_ENQ, 0x00, 0x00, instructionBytes[0], instructionBytes[1], wait,
			dataBytes[0], dataBytes[1], dataBytes[2], dataBytes[3] 			
		};
		
		short sum = 0;
		foreach(var byteValue in contentBytes)
		{
			sum += byteValue;
		}
		
		var sumBytes = BitConverter.GetBytes(sum);
		
		var messageBytes = contentBytes.Concat(new byte[] { sumBytes[0], sumBytes[1], C_CR } );
		
		itsPort.Write(messageBytes, 0, 13);
