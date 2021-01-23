	[MessageContract]
	public class DataTransfer
	{
		[MessageHeader(MustUnderstand = true)]
		public DataContract.HandShake Handshake { get; set; }
		[MessageBodyMember(Order = 1)]
		public Stream Data { get; set; }
	}
