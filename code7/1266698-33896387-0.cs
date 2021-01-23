	namespace LicenseWatchingServiceLibrary
	{
		[DataContract]
		public partial class LicenseInfoContainerExpiring : ILicenseInfoContainer
		{
			#region precode
			#region properties
			[DataMember]
			public string licenseName { get; set; } 
			[DataMember]
			public DateTime licenseExpirationDate { get; set; }
			
			// ...
		}
	}
