    public class UserAddress
    {
        [Exist("dbo.Cities", "city_id")]
        public int CityCode { get; set; }
        [Exist("dbo.Countries", "country_id")]
        public int CountryCode { get; set; }
    }
