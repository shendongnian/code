       public class CountryDTO
        {
    
            public int CountryId { get; set; }
    
            [Display(Name = "Country Name")]
            [Required(ErrorMessage = "This field is required")]
            public string CountryName { get; set; }
    
            [Display(Name = "Latitude")]
            [Required(ErrorMessage = "This field is required")]
            public double CentralLat { get; set; }
    
            [Display(Name = "Longitude")]
            [Required(ErrorMessage = "This field is required")]
            public double CentralLang { get; set; }
    
            [Display(Name = "GMT Offset")]
            [Required(ErrorMessage = "This field is required")]
            public double GMTOffSet { get; set; }
    
            [Display(Name = "Currency")]
            [Required(ErrorMessage = "This field is required")]
            public string Currency { get; set; }
        }
