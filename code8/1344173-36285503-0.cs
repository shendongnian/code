    [DataContract(Namespace = Namespaces.V1)]
	public enum AreaType : int
	{
		[EnumMember]
		Unknown = 0,
		[EnumMember]
		Urban = 1,
		[EnumMember]
		Suburban = 2,
		[EnumMember]
		Rural = 3
	}
