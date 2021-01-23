    public class ARCCreateModel
    {
        public ARCCreateModel()
        {
            this.Details = new List<ARCCreateDetail>();
        }
        public List<ARCCreateDetail> Details { get; set; }
    }
    public class ARCCreateDetail
    {
        [Display(Name = "Periode")]
        [Required]
        [RegularExpression("[2][0]([1][4-9]|[2-9][0-9])(0[1-9]|1[012])", ErrorMessage = "Format tidak sesuai. Contoh format : 201407 (Juli 2014)")]
        public int Periode { get; set; }
    
        [Display(Name = "Email SPDT")]
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime EmailSPDT { get; set; }
    
        [Display(Name = "Jatuh Tempo")]
        [Required]
        public DateTime JatuhTempoDT { get; set; }
    
    }
