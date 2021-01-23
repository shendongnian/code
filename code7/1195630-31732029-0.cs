        /// <summary>
        /// Gets or sets the country code, and province or state code delimited by a vertical pipe: <c>US|MI</c>
        /// </summary>
        [JsonIgnore]
        public string CountryProvinceState
        {
            get
            {
                return string.Format("{0}|{1}", this.CountryCode, this.ProvinceState);
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Contains("|"))
                {
                    string[] valueParts = value.Split('|');
                    if (valueParts.Length == 2)
                    {
                        this.CountryCode = valueParts[0];
                        this.ProvinceState = valueParts[1];
                    }
                }
            }
        }
        [JsonProperty("countryProvinceState")]
        string ReadCountryProvinceState
        {
            get { return CountryProvinceState; } 
        }
