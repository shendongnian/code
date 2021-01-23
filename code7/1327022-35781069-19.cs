	[DataContract]
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class Activities : IEnumerable<Activity>
	{
		private List<Activity> _list;
		[DataMember]
		[JsonProperty]
		public List<Activity> List
		{
			get { return this._list; }
			set { this._list = value; }
		}
		// Remainder unchanged.
	}
