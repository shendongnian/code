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
		result.ServerId = byte[0];
		result.FunctionCode = byte[1];
		
		stringLength = byte[2];
		
		result.Payload = Encoding.ASCII.GetString(message, 3, stringLength);
		// TODO: CRC
		
		return result;
		
	}
	
	
