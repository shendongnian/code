	//dog.generated.cs
	partial class Dog
	{
		public int DogId { get; set; }
		public string Name { get; set; }
	}
	//dog.cs
	[MetadataType(typeof(DogMetadata))]
	partial class Dog {}
	class DogMetadata
	{
		[DisplayName("My dog")]
		public string Name { get; set; }
	}
