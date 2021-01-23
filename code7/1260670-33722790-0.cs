    internal class Airport
    {
        private string _airportName;
        private double _celsiusTemperature;
        private double _elevation;
        public Airport(string airportName, double celsiusTemperature, double elevation)
        {
            this._airportName = airportName;
            this._celsiusTemperature = celsiusTemperature;
            this._elevation = elevation;
        }
        public string AirportName
        {
            get
            {
                return _airportName;
            }
            set
            {
                _airportName = value;
            }
        }
        public double CelsiusTemperature
        {
            get
            {
                return _celsiusTemperature;
            }
            set
            {
                _celsiusTemperature = value;
            }
        }
        public double Elevation
        {
            get
            {
                return _elevation;
            }
            set
            {
                _elevation = value;
            }
        }
        public double TemperatureInFahrenheit
        {
            get
            {
                return _celsiusTemperature * (1.8) + 32.0;
            }
            set
            {
                if (value != 32.0)
                {
                    _celsiusTemperature = (value - 32.0) / (1.8);
                }
                else
                {
                    _celsiusTemperature = 0.0;
                }
            }
        }
        public bool IsValid(out string errorMessage)
        {
            bool result = false;
            bool ok = true;
            errorMessage = "";
            if (String.IsNullOrEmpty(_airportName))
            {
                ok = false;
                errorMessage = "You did not enter a name for the airport.";
            }
            if (_celsiusTemperature > 50 || _celsiusTemperature < -50)
            {
                ok = false;
                errorMessage = "The value you entered for temperature is outside the acceptable range.";
            }
            if (_elevation > 12000 || _elevation < -300)
            {
                ok = false;
                errorMessage = "The value you entered for elevation is outside the acceptable range.";
            }
            result = ok;
            return result;
        }
    }
