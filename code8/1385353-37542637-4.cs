	[MessageContract]
	public class DataTransfer
	{
		[MessageHeader(MustUnderstand = true)]
		public DataContract.HandShake Handshake { get; set; }
		[MessageBodyMember(Order = 1)]
		public Stream Data { get; set; }
        //notice that it is using the default stream not a file stream, this is because the filestream you pass in has to be changed to a network stream to be sent via WCF
	}
