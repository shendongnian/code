	public class ModbusRequest
	{
		public byte ServerId { get; set; }
		public byte FunctionCode { get; set; }
		public string Payload { get; set; }
	}
	
	public ModbusRequest DecodeMessage(byte[] message)
	{
		var result = new ModbusRequest();
		
		// Simply copy bytes 0 and 1 into the destination structure.
		result.ServerId = message[0];
		result.FunctionCode = message[1];
		
		byte stringLength = message[2];
        // Assuming ASCII encoding, see docs.
		result.Payload = Encoding.ASCII.GetString(message, 3, stringLength);
		// Get the CRC bytes.
        byte[] crc = new byte[2];
        Buffer.BlockCopy(message, 4 + stringLength, crc, 0, 2);
        // TODO: verify CRC.
		return result;
		
	}
	
	
