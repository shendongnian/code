	public class Message
	{
		public static readonly byte BOM = 0x81;
		public static readonly byte EOM = 0x82;
		public static readonly byte Control = 0x1B;
	
		public byte[] Header { get; set; }
		public byte[] Data { get; set; }
	
		public static Message Create(byte[] bytes)
		{	
			if(bytes==null)
				throw new ArgumentNullException(nameof(bytes));
			if(bytes.Length<3)
				throw new ArgumentException("bytes<3").Dump();
			
	
			var header = new byte[3];
			Array.Copy(bytes, header, 3);
			
			var body = new List<byte>();
			var escapeNext = false;
			for (int i = 3; i < bytes.Length; i++)
			{
				var b = bytes[i];
				
				if (b == Control && !escapeNext)
				{
					escapeNext = true;
				}
				else
				{
					body.Add(b);
					escapeNext = false;
				}
			}
			var msg = new Message { Header = header, Data = body.ToArray()};
			return msg;
		}
	
		public override string ToString()
		{
			return string.Format("Message(Header=[{0}], Data=[{1}])", ByteArrayString(Header), ByteArrayString(Data));
		}
	
		private static string ByteArrayString(byte[] bytes)
		{
			return string.Join(",", bytes.Select(b => b.ToString("X")));
		}
	
		public override bool Equals(object obj)
		{
			var other = obj as Message;
			if(obj==null)
				return false;
			return Equals(other);
		}
	
		protected bool Equals(Message other)
		{
			return IsSequenceEqual(Header, other.Header) 
				&& IsSequenceEqual(Data, other.Data);
		}
	
		private bool IsSequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> other)
		{
			if(expected==null && other==null)
				return true;
			if(expected==null || other==null)
				return false;
			return expected.SequenceEqual(other);
		}
	
		public override int GetHashCode()
		{
			unchecked
			{
				return ((Header != null ? Header.GetHashCode() : 0) * 397) ^ (Data != null ? Data.GetHashCode() : 0);
			}
		}
	}
