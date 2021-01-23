        public string this[int countryId]
        {
            get
            {
                if(!_dictCountries.ContainsKey(countryId))
                {
                    throw new ArgumentOutOfRangeException("countryId");
                }
                return _dictCountries[countryId].Name;
            }
            set
            {
                if(!_dictCountries.ContainsKey(countryId))
                {
                    throw new ArgumentOutOfRangeException("countryId");
                }
                _dictCountries[countryId].Name = value;
            }
        }
