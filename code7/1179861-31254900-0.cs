	[DataContract]
	class Hull
	{
		public int Width { get; set; }
		public int Height { get; set; }
		[DataMember]
		public List<Component> Components { get; set; } 
		//read only properties will be ignored
		public int SurfaceArea { get { return Width*Height; }}
		//some properties can be excluded from serialization:
		[IgnoreDataMember]
		public int NotStoredInXml { get; set; }
		public Hull()
		{
			this.Components = new List<Component>();
		}
	}
	[DataContract]
	[KnownType(typeof(Room))]
	[KnownType(typeof(ComputerRoom))]
	[KnownType(typeof(System))]
	abstract class Component
	{
		[DataMember]
		int Width { get; set; }
		[DataMember]
		int Height { get; set; }
		[DataMember]
		int X { get; set; }
		[DataMember]
		int Y { get; set; }
	}
	[DataContract] class Room : Component { }
	[DataContract] class System : Component { }
	[DataContract] class ComputerRoom : Room
	{
		[DataMember]
		public int NumberOfCPUCores { get; set; }
	}
