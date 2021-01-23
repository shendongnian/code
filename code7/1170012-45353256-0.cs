    [MetadataType(typeof(TheMetaDataYouWantTheTypeFrom))]
    public class ObjectYouWantMetaDataTypeFrom
    {
        public string Username { get; set; }
        public string Name { get; set; }
    }
    public class TheMetaDataYouWantTheTypeFrom
    {
        [Required(ErrorMessage = "You must enter a username.")]
        public object Username { get; set; }
        [Required(ErrorMessage = "You must enter a name.")]
        public object Name { get; set; }
    }
