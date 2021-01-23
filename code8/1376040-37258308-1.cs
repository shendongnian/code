	[DataContract]
	public class eMailAddress
	{
		[DataMember]
		private string _Address;
		public string Address
		{
			get
			{
				return _Address;
			}
			set
			{
				_Address = Address;
			}
		}
		...
	}
