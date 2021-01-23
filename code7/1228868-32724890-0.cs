    Public Class AddressViewModel
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }       
        public int CityCityId { get; set; }
        [DisplayName("City Name")]
        public string CityCityName { get; set; }
        public int CityCountryCountryId { get; set; }
        [DisplayName("Country Name")]
        public string CityCountryCountryName { get; set}
    }
