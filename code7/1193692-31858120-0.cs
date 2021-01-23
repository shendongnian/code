    /// <summary>
	/// 
	/// </summary>
	[DataContract]
	public class EmailAddress
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		[EmailAddress]
		public string Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[DataMember(Name = "Name")]
		public string DisplayName { get; set; }
	}
