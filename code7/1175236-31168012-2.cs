        public bool Validate(object value)
        {
            //Validate your city here
            var connection = ; // create connection
            var cityRepository = new CityRepository(connection);
            if (!cityRepository.IsValidCityCode((int)value))
            {
                // Added Model error
                this.ErrorMessage = "City already exists";
            }
            return true;
        }
