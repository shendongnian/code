    using System.ComponentModel.DataAnnotations;
    // Other using may go there
    
    public class DummyModel 
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReleaseDate { get; set;}
    }
