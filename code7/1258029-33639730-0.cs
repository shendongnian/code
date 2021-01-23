    public static string getState()
            {
                string state = GenerateCityStateZip.GenRandomState();
                return state;
            }
            public string _state = getState();
      public static string getCity(string state)
        {
            string city = GenerateCityStateZip.GetCity(state);
            return city;
        }
    
        public static string getZip(string state)
        {
            string zip = GenerateCityStateZip.GetZip(state);
            return zip;
        }
