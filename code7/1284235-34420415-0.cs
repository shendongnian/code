        [WebMethod]
        public List<object> AccessRemoteData(string q)
        {
            Dictionary<string, string> dictCountry = new Dictionary<string, string>();
            dictCountry.Add("1", "India");
            dictCountry.Add("2", "Canada");
            dictCountry.Add("3", "United States");
            dictCountry.Add("4", "United Kingdom");
            dictCountry.Add("5", "United Arab Emirates");
            List<object> CountryList = new List<object>();
            Select2DTO singleCountry;
            var selectedCountryList = dictCountry.Where(m => m.Value.ToLower().Contains(q)).ToList();
            foreach (var selectedCountry in selectedCountryList)
            {
                singleCountry = new Select2DTO();
                singleCountry.id = selectedCountry.Key;
                singleCountry.text = selectedCountry.Value;
                CountryList.Add(singleCountry);
            }
            return CountryList;
        }
