    public class StateProvinceEdition : StateProvince
    {
        public string CountryRegionName { get; set; }
        public StateProvinceEdition(StateProvince stateProvince, string countryRegionName)
        {
            this.StateProvinceID = stateProvince.StateProvinceID;
            // And so on ...
            // Adding country region name
            this.CountryRegionName = countryRegionName;
        }
    }
