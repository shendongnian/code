	public class ZllnpMessage
	{
		public string Head { get; set; }
		
		public byte[] CalculateHash()
		{
			// return hash
		}
		
		public byte[] ToBinary()
		{
			CalculateHash();
			// return serialized message
		}
	}
