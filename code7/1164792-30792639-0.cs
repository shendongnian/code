	public class DataMember
	{
		public string ID { get; set; }
		public HashSet<string> Versions { get; set; } // using hashset is faster here.
	}
	public class MasterDataMember
	{
		public string ID { get; set; }
		public HashSet<string> FoundVersions { get; set; } // used HashSet for consistency, but for the purposes of the algorithm, a List can still be used here if you want.
	}
