	[MessageContract]
	public class DataTransfer
	{
		[MessageHeader(MustUnderstand = true)]
		public DataContract.HandShake Handshake { get; set; }
		[MessageBodyMember(Order = 1)]
		public Stream Data { get; set; }
	}
	public SaveResponse SaveData(DataTransfer request)
	{
		using (var stream = new System.IO.MemoryStream())
		{
			request.Data.CopyTo(stream);
			stream.Position = 0;
            //this is because you have less control of a stream over a netwrok than one held locally so by copying from the network to a local stream you then have more control
