    public class LookUpViewModel
        {    
            [Required]
            public virtual IEnumerable<tblCurrentLocation> tblCurrentLocations { get; set; }
    
            [Required]
            public virtual IEnumerable<tblStream> tblStreams {  get;  set; }
