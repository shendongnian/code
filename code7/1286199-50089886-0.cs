    public partial class Hazaa : EntityBase
    {
        public int Shazoo { get; set; }
    }
    [MetadataTypeAttribute(typeof(HazaaMetadata))]
    public partial class Hazaa : EntityBase
    {
        internal sealed class HazaaMetadata
        {
	        [SuperCool]
            public int Shazoo { get; set; }
        }
    }
