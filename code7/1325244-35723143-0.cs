	public class ZllnpMessage
	{
		private bool _autoHash;
		private string _head;
		public string Head 
		{ 
			get { return _head; } 
			set 
			{
				_head = value;
				if (_autoHash)
				{
					CalculateHash();
				}
			} 
		}
		
		public ZllnpMessage(bool autoHash)
		{
			_autoHash = autoHash;
		}
		
		public byte[] CalculateHash()
		{
			// return hash
		}
		
		public byte[] ToBinary()
		{
			// return serialized message
		}
	}
	
