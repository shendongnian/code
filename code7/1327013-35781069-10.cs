	[DataContract]
	public class Activities : IEnumerable<Activity>
	{
		private List<Activity> _list;
		[DataMember]
		public List<Activity> List
		{
			get { return this._list; }
			set { this._list = value; }
		}
		// ...
	}
